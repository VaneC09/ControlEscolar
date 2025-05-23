using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControlEscolarCore.Model;
using ControlEscolarCore.Data;
using ControlEscolarCore.Utilities;
using NLog;
using OfficeOpenXml;


namespace ControlEscolarCore.Controller
{
    public class EstudiantesController
    {
        private static readonly Logger _logger = LogManager.GetLogger("DiseñoForms.Controller.EstudiantesController");
        private readonly EstudiantesDataAccess _estudiantesData;
        private readonly PersonasDataAccess _personasData;

        public EstudiantesController()
        {
            try
            {
                _estudiantesData = new EstudiantesDataAccess();
                _personasData = new PersonasDataAccess();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al crear la conexión a la base de datos");
                throw;
            }
        }

        public List<Estudiante> ObtenerTodosLosEstudiantes(bool soloActivos = true, int tipofecha = 0, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                //Obtener los estudiantes de la capa de acceso a datos
                var estudiantes = _estudiantesData.ObtenerTodosLosEstudiantes(soloActivos, tipofecha, fechaInicio);
                _logger.Info($"Se obtuvieron {estudiantes.Count} estudiantes correctamente");
                return estudiantes;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener la lista de los estudiantes");
                throw; //Propagar la excepción
            }
        }

        /// <summary>
        /// Registra un nuevo estudiante en el sistema
        /// </summary>
        /// <param name="estudiante">Objeto Estudiante con todos los datos para registro</param>
        /// <returns>Tupla con (id del estudiante, mensaje de resultado)</returns>
        public (int id, string mensaje) RegistrarEstudiante(Estudiante estudiante)
        {
            try
            {
                // Verificar si la matrícula ya existe
                if (_estudiantesData.ExisteMatricula(estudiante.Matricula))
                {
                    _logger.Warn($"Intento de registrar estudiante con matrícula duplicada: {estudiante.Matricula}");
                    return (-3, $"La matrícula {estudiante.Matricula} ya está registrada en el sistema");
                }

                // Verificar si el CURP ya existe
                if (_personasData.ExisteCurp(estudiante.DatosPersonales.Curp))
                {
                    _logger.Warn($"Intento de registrar estudiante con CURP duplicado: {estudiante.DatosPersonales.Curp}");
                    return (-2, $"El CURP {estudiante.DatosPersonales.Curp} ya está registrado en el sistema");
                }

                // Registrar el estudiante
                _logger.Info($"Registrando nuevo estudiante: {estudiante.DatosPersonales.NombreCompleto}, Matrícula: {estudiante.Matricula}");
                int idEstudiante = _estudiantesData.InsertarEstudiante(estudiante);

                if (idEstudiante <= 0)
                {
                    return (-4, "Error al registrar el estudiante en la base de datos");
                }

                _logger.Info($"Estudiante registrado exitosamente con ID: {idEstudiante}");
                return (idEstudiante, "Estudiante registrado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al registrar estudiante: {estudiante.DatosPersonales?.NombreCompleto ?? "Sin nombre"}, Matrícula: {estudiante.Matricula}");
                return (-5, $"Error inesperado: {ex.Message}");
            }
        }

        public Estudiante? ObtenerDetalleEstudiante(int idEstudiante)
        {
            try
            {
                _logger.Debug($"Solicitando detalle del estudiante con ID: {idEstudiante}");
                return _estudiantesData.ObtenerEstudiantePorId(idEstudiante);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener los detalles del estudiante con ID: {idEstudiante}");
                throw;
            }
        }

        public (bool exito, string mensaje) ActualizarEstudiante(Estudiante estudiante)
        {
            try
            {
                // Validaciones básicas
                if (estudiante == null)
                {
                    return (false, "No se proporcionaron datos del estudiante");
                }
                if (estudiante.Id <= 0)
                {
                    return (false, "ID de estudiante no válido");
                }
                if (estudiante.DatosPersonales == null)
                {
                    return (false, "No se proporcionaron los datos personales del estudiante");
                }

                // Verificar si el estudiante existe
                Estudiante? estudianteExistente = _estudiantesData.ObtenerEstudiantePorId(estudiante.Id);

                if (estudianteExistente == null)
                {
                    return (false, $"No se encontró el estudiante con ID {estudiante.Id}");
                }

                // Verificar que la matrícula no esté duplicada (si ha cambiado)
                if (estudiante.Matricula != estudianteExistente.Matricula &&
                    _estudiantesData.ExisteMatricula(estudiante.Matricula))
                {
                    return (false, $"La matrícula {estudiante.Matricula} ya está registrada en el sistema");
                }

                // Verificar que el CURP no esté duplicado (si ha cambiado)
                if (estudiante.DatosPersonales.Curp != estudianteExistente.DatosPersonales.Curp)
                {
                    // Buscar si existe otra persona con el mismo CURP que no sea la persona de este estudiante
                    bool personaConMismoCurp = _personasData.ExisteCurp(estudiante.DatosPersonales.Curp);
                    if (personaConMismoCurp)
                    {
                        return (false, $"El CURP {estudiante.DatosPersonales.Curp} ya está registrado para otra persona");
                    }
                }

                // Actualizar el estudiante
                _logger.Info($"Actualizando estudiante con ID: {estudiante.Id}, Nombre: {estudiante.DatosPersonales.NombreCompleto}");
                bool resultado = _estudiantesData.ActualizarEstudiante(estudiante);
                if (!resultado)
                {
                    _logger.Error($"Error al actualizar el estudiante con ID {estudiante.Id}");
                    return (false, "Error al actualizar el estudiante en la base de datos");
                }

                _logger.Info($"Estudiante con ID {estudiante.Id} actualizado exitosamente");
                return (true, "Estudiante actualizado exitosamente");
            }
            catch (Exception ex)
            {
                _logger.Error($"Error inesperado al actualizar estudiante: {ex.Message}");
                return (false, "Error inesperado al actualizar el estudiante");
            }
        }

        public bool ExportarEstudiantesExcel(string rutaArchivo, bool soloActivos = true,
     int tipoFecha = 0, DateTime? fechaInicio = null, DateTime? fechaFin = null)
        {
            try
            {
                //obtener los estudiantes
                var estudiantes = ObtenerTodosLosEstudiantes(soloActivos, tipoFecha, fechaInicio, fechaFin);
                if (estudiantes == null || estudiantes.Count == 0)
                {
                    _logger.Warn("No se encontraron estudiantes para exportar");
                    return false;
                }
                // Crear el archivo Excel-workbook (libro)
                using (var packege = new ExcelPackage())
                {
                    // Crear una hoja de trabajo
                    var worksheet = packege.Workbook.Worksheets.Add("Estudiantes");
                    //establecemos el encabezado
                    worksheet.Cells[1, 1].Value = "Matricula";
                    worksheet.Cells[1, 2].Value = "Nombre Completo";
                    worksheet.Cells[1, 3].Value = "Semestre";
                    worksheet.Cells[1, 4].Value = "Correo";
                    worksheet.Cells[1, 5].Value = "Telefono";
                    worksheet.Cells[1, 6].Value = "CURP";
                    worksheet.Cells[1, 7].Value = "Fecha de Nacimiento";
                    worksheet.Cells[1, 8].Value = "Fecha de Alta";
                    worksheet.Cells[1, 9].Value = "Fecha de Baja";
                    worksheet.Cells[1, 10].Value = "Estado";

                    // Aplicar formato a los encabezados 
                    //objeto probisional para no llenar la materia 
                    using (var range = worksheet.Cells[1, 1, 1, 10])
                    {
                        // Establecer el formato de la celda
                        range.Style.Font.Bold = true;
                        range.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        range.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                        range.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thin);
                    }

                    // Llenar los datos de los estudiantes
                    int row = 2;
                    foreach (var estudiante in estudiantes)
                    {
                        worksheet.Cells[row, 1].Value = estudiante.Matricula;
                        worksheet.Cells[row, 2].Value = estudiante.DatosPersonales.NombreCompleto;
                        worksheet.Cells[row, 3].Value = estudiante.Semestre;
                        worksheet.Cells[row, 4].Value = estudiante.DatosPersonales.Correo;
                        worksheet.Cells[row, 5].Value = estudiante.DatosPersonales.Telefono;
                        worksheet.Cells[row, 6].Value = estudiante.DatosPersonales.Curp;
                        worksheet.Cells[row, 7].Value = estudiante.DatosPersonales.FechaNacimiento;
                        worksheet.Cells[row, 8].Value = estudiante.FechaAlta;
                        worksheet.Cells[row, 9].Value = estudiante.FechaBaja;
                        worksheet.Cells[row, 10].Value = estudiante.DescripcionEstatus;
                    
                        //Aplicar formato a las fechas
                        if (estudiante.DatosPersonales.FechaNacimiento.HasValue)
                        {
                            worksheet.Cells[row, 7].Style.Numberformat.Format = "dd/MM/yyyy";
                        }

                        worksheet.Cells[row, 8].Style.Numberformat.Format = "dd/MM/yyyy";
                        if (estudiante.FechaBaja.HasValue)
                        {
                            worksheet.Cells[row, 9].Style.Numberformat.Format = "dd/MM/yyyy";
                        }
                        row++;
                    }
                    //Ajustar el ancho de las columans
                    worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                    // Guardar el archivo Excel
                    FileInfo fileInfo = new FileInfo(rutaArchivo);
                    packege.SaveAs(fileInfo); ;

                    _logger.Info($"Archivo Excel exportado correctamente a {rutaArchivo}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al exportar estudiantes a Excel");
                throw;
            }

        }

    }
}