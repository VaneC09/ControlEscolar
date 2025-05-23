using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ControlEscolarCore.Bussines;
using ControlEscolarCore.Controller;
using ControlEscolarCore.Model;
using ControlEscolar.Utilities;
using DocumentFormat.OpenXml.Office2010.Excel;
using static System.Runtime.InteropServices.JavaScript.JSType;

using Color = System.Drawing.Color;


namespace ControlEscolar.View
{
    public partial class frmEstudiantes : Form
    {
        public frmEstudiantes(Form parent)
        {
            InitializeComponent();
            Formas.InicializaForma(this, parent);
        }

        private void frmEstudiantes_Load(object sender, EventArgs e)
        {
            InicializaVentanaEstudiantes();
        }

        private void InicializaVentanaEstudiantes()
        {
            PoblaComboTipoFecha();
            PoblaComboEstatus();
            //solo para que salga lado derecho
            scEstudiantes.Panel1Collapsed = true;
            //fecha de hoy
            dtpFechaAlta.Value = DateTime.Now;
            cargarEstudiantes();
        }

        private bool DatosValidos()
        {
            if (!EstudianteNegocio.EsCorreoValido(txtCorreo.Text.Trim()))
            {
                MessageBox.Show("Correo inválido.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!EstudianteNegocio.EsCURPValido(txtCURP.Text.Trim()))
            {
                MessageBox.Show("CURP inválida.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (!EstudianteNegocio.EsNoControlValido(txtNoControl.Text.Trim()))
            {
                MessageBox.Show("Número de control inválido.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool DatosVacios()
        {
            if (txtNombre.Text == "" || txtCorreo.Text == "" || txtTelefono.Text == ""
                || txtCURP.Text == "" || upSemestre.Text == "" || txtNoControl.Text == ""
                || upSemestre.Text == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void PoblaComboEstatus()
        {
            //Crear un diccionario con los valores
            Dictionary<int, string> list_estatus = new Dictionary<int, string>
            {
                { 1, "Activo" },
                { 0, "Baja" },
                { 2, "Baja Temporal" }
            };

            //Asignar los valores al comboBox
            cmbEstatus.DataSource = new BindingSource(list_estatus, null);
            cmbEstatus.DisplayMember = "Value"; //lo que se mestra
            cmbEstatus.ValueMember = "Key"; //lo que se guarda como SelectedValue

            cmbEstatus.SelectedIndex = 2;
        }

        private void PoblaComboTipoFecha()
        {
            //Crear un diccionario con los valores
            Dictionary<int, string> list_tipo_fechas = new Dictionary<int, string>
            {
                { 1, "Nacimiento" },
                { 2, "Alta" },
                { 3, "Baja" }
            };

            //Asignar los valores al comboBox
            cmbTipoFecha.DataSource = new BindingSource(list_tipo_fechas, null);
            cmbTipoFecha.DisplayMember = "Value"; //lo que se mestra
            cmbTipoFecha.ValueMember = "Key"; //lo que se guarda como SelectedValue

            cmbTipoFecha.SelectedIndex = 2;

        }

        private void btnMostrarCaptura_Click(object sender, EventArgs e)
        {
            if (scEstudiantes.Panel1Collapsed)
            {
                scEstudiantes.Panel1Collapsed = false;
                btnMostrarCaptura.Text = "Ocultar captura rápida";
            }
            else
            {
                scEstudiantes.Panel1Collapsed = true;
                btnMostrarCaptura.Text = "Mostrar captura rápida";
            }
        }

        private void btnCargaMasiva_Click(object sender, EventArgs e)
        {
            ofdArchivo.Title = "Seleccionar archivo de Excel";
            ofdArchivo.Filter = "Archivos de excel (*.xlsx;*.xls)|*.xlsx;*.xls";
            ofdArchivo.InitialDirectory = "C:\\";//carpeta inicial
            ofdArchivo.FilterIndex = 1; //selecciona el primer filtro por defecto
            ofdArchivo.RestoreDirectory = true; //mantiene la ultima ruta utilizada

            //showdialog espera una respuesta
            if (ofdArchivo.ShowDialog() == DialogResult.OK)
            {
                string filePath = ofdArchivo.FileName;
                string extension = Path.GetExtension(filePath).ToLower();

                if (extension == ".xlsx" || extension == ".xls")
                {
                    MessageBox.Show("Archivo válido: " + filePath, "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Por favor, selecciona un archivo de Excel válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Determinar si estamos en modo edición o nuevo registro
            if (btnGuardar.Text == "Actualizar") // Modo edición
            {
                ActualizarEstudiante();
            }
            else // Modo nuevo registro
            {
                GuardarEstudiante();
            }
        }

        private void GuardarEstudiante()
        {
            try
            {
                //Validaciones a nivel de interfaz
                if (DatosVacios())
                {
                    MessageBox.Show("Por favor, llene todos los campos.", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DatosValidos())
                {
                    return;
                }

                //Crear el objeto Persona con los datos del formulario
                Persona persona = new Persona(
                    txtNombre.Text.Trim(),
                    txtCorreo.Text.Trim(),
                    txtTelefono.Text.Trim(),
                    txtCURP.Text.Trim()
                );

                //Asignar la fecha de nacimiento
                persona.FechaNacimiento = dtpFechaDeNacimiento.Value;

                //Crear el objeto Estudiante con los datos del formulario
                Estudiante estudiante = new Estudiante
                {
                    Matricula = txtNoControl.Text.Trim(),
                    Semestre = upSemestre.Text.Trim(),
                    FechaAlta = dtpFechaAlta.Value,
                    Estatus = 1, //Activo por defecto
                    DatosPersonales = persona
                };

                //Crear instancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                //Llamar al método para registrar el estudiante utilizando el modelo
                var (idEstudiante, mensaje) = estudiantesController.RegistrarEstudiante(estudiante);

                //Verificar el resultado
                if (idEstudiante > 0)
                {
                    //Mostrar mensaje de éxito
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCampos(); //Metodo para limpiar el formulario despues de guardar

                    //Acttualizar la lista de estudiantes si esta presente en la misma vista
                    cargarEstudiantes();
                }
                else
                {
                    //Mostrar mensaje de error devuelto por el controlador
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    //Enfocar el campo apropiado basado en el codigo de error
                    switch (idEstudiante)
                    {
                        case -2: //Error de CURP duplicado
                            txtCURP.Focus();
                            txtCURP.SelectAll();
                            break;
                        case -3: //Error de matrícula duplicada
                            txtNoControl.Focus();
                            txtNoControl.SelectAll();
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                //El detalle del error ya se guardara en el log por el controlador
                MessageBox.Show("No se pudo completar el registro del estudiante. Por favor, intente nuevamente o contacte al administrador del sistema.", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtCorreo.Clear();
            txtTelefono.Clear();
            txtCURP.Clear();
            upSemestre.Value = 1;
            txtNoControl.Clear();
            dtpFechaDeNacimiento.Value = DateTime.Now;
            dtpFechaAlta.Value = DateTime.Now;
            cmbEstatus.SelectedIndex = 1;
            cmbTipoFecha.SelectedIndex = 1;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            cargarEstudiantes();
        }

        private void cargarEstudiantes()
        {
            try
            {
                //Mostrar el cursor de espera
                Cursor = Cursors.WaitCursor;

                //Crear una instancia de acceso al controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                //Obtener la lista de estudiantes
                List<Estudiante> estudiantes = estudiantesController.ObtnerTodosLosEstudiantes(
                    soloActivos: false,
                    tipofecha: cmbTipoFecha.SelectedValue != null ? (int)cmbTipoFecha.SelectedValue : 0,
                    fechaInicio: dtpFechaInicio.Enabled ? dtpFechaInicio.Value : (DateTime?)null,
                    fechaFin: dtpFechaFin.Enabled ? dtpFechaFin.Value : (DateTime?)null);

                //Limpiar el DataGridView
                //dgvEstudiantes.Rows.Clear();

                if (estudiantes.Count == 0)
                {
                    lblTotalRegistros.Text = "Total: 0 registros";

                    if (!string.IsNullOrEmpty(txtBusqueda.Text))
                    {
                        MessageBox.Show("No se encontraron estudiantes con el criterio de busqueda ", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                //Crear y poblar el DataTable
                DataTable dt = new DataTable();
                dt.Columns.Add("ID", typeof(int));
                dt.Columns.Add("Matrícula", typeof(string));
                dt.Columns.Add("Nombre Completo", typeof(string));
                dt.Columns.Add("Semestre", typeof(string));
                dt.Columns.Add("Correo", typeof(string));
                dt.Columns.Add("Teléfono", typeof(string));
                dt.Columns.Add("CURP", typeof(string));
                dt.Columns.Add("Fecha Nacimiento", typeof(DateTime));
                dt.Columns.Add("Fecha Alta", typeof(DateTime));
                dt.Columns.Add("Estatus", typeof(string));

                foreach (Estudiante estudiante in estudiantes)
                {
                    dt.Rows.Add(
                        estudiante.Id,
                        estudiante.Matricula,
                        estudiante.DatosPersonales.NombreCompleto,
                        estudiante.Semestre,
                        estudiante.DatosPersonales.Correo,
                        estudiante.DatosPersonales.Telefono,
                        estudiante.DatosPersonales.Curp,
                        estudiante.DatosPersonales.FechaNacimiento,
                        estudiante.FechaAlta,
                        estudiante.DescripcionEstatus
                    );
                }

                //Asignar el DataTable al DataGridView
                dgvEstudiantes.DataSource = dt;

                //Configurar el DataGridView
                ConfigurarDataGridView();

                //Actualizar el total de registros
                lblTotalRegistros.Text = $"Total: {estudiantes.Count} registros";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los estudiantes. Contacta al administrador del sistema.", "Error del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Restaurar el cursor
                Cursor = Cursors.Default;
            }
        }

        private void ConfigurarDataGridView()

        {
            //Ajustes generales
            dgvEstudiantes.AllowUserToAddRows = false;
            dgvEstudiantes.AllowUserToDeleteRows = false;
            dgvEstudiantes.ReadOnly = true;

            // Ajustar el ancho de las columnas
            dgvEstudiantes.Columns["Matrícula"].Width = 100;
            dgvEstudiantes.Columns["Nombre Completo"].Width = 200;
            dgvEstudiantes.Columns["Semestre"].Width = 80;
            dgvEstudiantes.Columns["Correo"].Width = 180;
            dgvEstudiantes.Columns["Teléfono"].Width = 120;
            dgvEstudiantes.Columns["CURP"].Width = 150;
            dgvEstudiantes.Columns["Fecha Nacimiento"].Width = 120;
            dgvEstudiantes.Columns["Fecha Alta"].Width = 120;
            dgvEstudiantes.Columns["Estatus"].Width = 100;

            // Ocultar columna ID si es necesario
            dgvEstudiantes.Columns["ID"].Visible = false;

            // Formato para las fechas
            dgvEstudiantes.Columns["Fecha Nacimiento"].DefaultCellStyle.Format = "dd/MM/yyyy";
            dgvEstudiantes.Columns["Fecha Alta"].DefaultCellStyle.Format = "dd/MM/yyyy";

            // Alineación
            dgvEstudiantes.Columns["ID"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvEstudiantes.Columns["Matrícula"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstudiantes.Columns["Semestre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvEstudiantes.Columns["Estatus"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            // Color alternado de filas
            dgvEstudiantes.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;

            // Selección de fila completa
            dgvEstudiantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Estilo de cabeceras
            dgvEstudiantes.EnableHeadersVisualStyles = false;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.BackColor = Color.SteelBlue;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Font = new Font(dgvEstudiantes.Font, FontStyle.Bold);
            dgvEstudiantes.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // Ordenar al hacer clic en el encabezado
            dgvEstudiantes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvEstudiantes.ColumnHeadersHeight = 35;
        }

        /// <summary>
        /// Actualiza los datos de un estudiante existente
        /// </summary>

        private void ActualizarEstudiante()
        {
            try
            {
                // Validaciones a nivel de interfaz
                if (DatosVacios())
                {
                    MessageBox.Show("Por favor, llene todos los campos.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (!DatosValidos())
                {
                    return;
                }
                // Obtener el ID del estudiante almacenado en el Tag
                if (this.Tag == null || !(this.Tag is int))
                {
                    MessageBox.Show("No se ha seleccionado un estudiante para actualizar.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                int idEstudiante = (int)this.Tag;

                // Crear el objeto Persona con los datos del formulario
                Persona persona = new Persona
                {
                    Id = 0, // Se actualizará con el valor correcto en el controlle
                    NombreCompleto = txtNombre.Text.Trim(),
                    Correo = txtCorreo.Text.Trim(),
                    Telefono = txtTelefono.Text.Trim(),
                    Curp = txtCURP.Text.Trim(),
                    FechaNacimiento = dtpFechaDeNacimiento.Value,
                    Estatus = true // Asumimos que la persona está activa
                };

                // Crear el objeto Estudiante con los datos del formulario
                Estudiante estudiante = new Estudiante
                {
                    Id = idEstudiante,
                    IdPersona = 6, // Se actualizará con el valor correcto en el controller
                    Matricula = txtNoControl.Text.Trim(),
                    Semestre = upSemestre.Text.Trim(),
                    FechaAlta = dtpFechaAlta.Value,
                    Estatus = cmbEstatus.SelectedValue != null ? (int)cmbEstatus.SelectedValue : 1, //0-Baja, 1-Activo, 2-Baja Temporal
                    DatosPersonales = persona
                };

                // Asignar fecha de baja si corresponde

                if (cmbEstatus.SelectedIndex == 0) // 51 el estatus es "Baja"
                {
                    estudiante.FechaBaja = dtpFechaBaja.Value;
                }
                else if (dtpFechaBaja.Enabled && cmbEstatus.SelectedIndex == 2) // Si es "Baja Temporal" y hay fecha
                {
                    estudiante.FechaBaja = dtpFechaBaja.Value;
                }
                else
                {
                    estudiante.FechaBaja = null;
                }
                // Crear instancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();

                // Llamar al método para actualizar el estudiante utilizando el modelo
                var (resultado, mensaje) = estudiantesController.ActualizarEstudiante(estudiante);

                // Verificar el resultado
                if (resultado)
                {
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Limpiar formulario y restablecer moda
                    LimpiarCampos();
                    ModoEdicion(false);

                    // Actualizar la lista de estudiantes
                    cargarEstudiantes();

                }
                else
                {
                    // Mostrar mensaje de error devuelto por el controlador
                    MessageBox.Show(mensaje, "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                // El detalle del error ya se guardará en el log por el controlador
                MessageBox.Show("No se pudo completar la actualización del estudiante. Por favor, intente nuevamente o contacte al administrador del sistema.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Obtiene los detalles del estudiante seleccionado y los muestra en el formulario.
        /// </summary>
        /// <param name="idEstudiante">ID del estudiante a obtener</param>
        private void ObtenerDetalleEstudiante(int idEstudiante)
        {
            try
            {
                // Llamar al controlador para obtener el estudiante
                EstudiantesController controller_estudiante = new EstudiantesController();
                Estudiante estudiante = controller_estudiante.ObtenerDetalleEstudiante(idEstudiante);

                if (estudiante != null)
                {
                    // Poblar los controles con la información del estudiante
                    CargarDatosEstudiante(estudiante);

                    // Cambiar a modo de edición
                    ModoEdicion(true);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener la información del estudiante.",
                                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los detalles del estudiante: {ex.Message}.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los datos del estudiante en los controles del formulario
        /// </summary>
        /// <param name="estudiante">Objeto Estudiante con los datos a mostrar</param>
        private void CargarDatosEstudiante(Estudiante estudiante)
        {
            // Datos personales
            txtNombre.Text = estudiante.DatosPersonales.NombreCompleto;
            txtCorreo.Text = estudiante.DatosPersonales.Correo;
            txtTelefono.Text = estudiante.DatosPersonales.Telefono;
            txtCURP.Text = estudiante.DatosPersonales.Curp;

            if (estudiante.DatosPersonales.FechaNacimiento.HasValue)
                dtpFechaDeNacimiento.Value = estudiante.DatosPersonales.FechaNacimiento.Value;
            else
                dtpFechaDeNacimiento.Value = DateTime.Now;

            // Datos del estudiante
            txtNoControl.Text = estudiante.Matricula;

            // Fechas
            dtpFechaAlta.Value = estudiante.FechaAlta;

            if (estudiante.FechaBaja.HasValue)
            {
                dtpFechaBaja.Value = estudiante.FechaBaja.Value;
                dtpFechaBaja.Enabled = true;
            }
            else
            {
                dtpFechaBaja.Value = DateTime.Now;
                dtpFechaBaja.Enabled = false;
            }

            // Estatus
            cmbEstatus.SelectedValue = estudiante.Estatus;

            // Guardar el ID en una propiedad o tag para usarlo al actualizar
            this.Tag = estudiante.Id;
        }


        /// <summary>
        /// Cambia el modo de operación entre nuevo registro y edición
        /// </summary>
        /// <param name="edicion">True para modo edición, False para modo nuevo registro</param>
        private void ModoEdicion(bool edicion)
        {
            // Cambiar título y configurar botones según el modo
            grbAltaOEdicion.Text = edicion ? "Editar Estudiante" : "Nuevo Estudiante";
            btnGuardar.Text = edicion ? "Actualizar" : "Guardar";

            // Si es modo edición, desactivar campos que no deberían modificarse
            txtNoControl.ReadOnly = edicion;

            // Activar el panel izquierdo para mostrar los detalles
            if (scEstudiantes.Panel1Collapsed)
            {
                scEstudiantes.Panel1Collapsed = false;
                btnMostrarCaptura.Text = "Ocultar captura rápida";
            }
        }

        private void editarEstudiante_Click(object sender, EventArgs e)
        {
            try
            {
                // Verificar si hay una fila seleccionada en el grid
                if (dgvEstudiantes.SelectedRows.Count > 0)
                {
                    // Obtener el ID del estudiante de la fila seleccionada 
                    int idEstudiante = Convert.ToInt32(dgvEstudiantes.SelectedRows[0].Cells["id"].Value);
                    // Llamar a la función para obtener y mostrar los detalles
                    ObtenerDetalleEstudiante(idEstudiante);
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione un estudiante para editar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al preparar la edición del estudiante: {ex.Message}",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void ImportarExcel()
        {
            try
            {
                //Crear instancia del controlador
                EstudiantesController estudiantesController = new EstudiantesController();
                //Obtener los filtros actuales de la interfaz 
                //bool soloActivos = true;
                bool soloActivos = chkSoloActivos.Checked;
                int tipofecha = cmbTipoFecha.SelectedValue != null ?
                    (int)cmbTipoFecha.SelectedValue : 0;
                DateTime? fechaInicio = dtpFechaInicio.Value;
                DateTime? fechaFin = dtpFechaFin.Value;

                //Mostrar  dialogo para guardar archivo
                using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Title = "Guardar archivo de Excel";
                    saveFileDialog.Filter = "Archivos de Excel (.xlsx)|.xlsx";
                    saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    saveFileDialog.FileName = $"Estudiantes_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        Cursor.Current = Cursors.WaitCursor;
                        bool resultado = estudiantesController.ExportarEstudiantesExcel(
                            saveFileDialog.FileName,
                            soloActivos,
                            tipofecha,
                            fechaInicio,
                            fechaFin
                        );

                        //Restaurar cursor normal
                        Cursor.Current = Cursors.Default;
                        //Verificar si se exportaron estudiantes
                        if (resultado)
                        {
                            MessageBox.Show("Archivo Excel exportado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //preguntar si desea abrir el archivo
                            DialogResult abrirArchivo = MessageBox.Show("¿Desea abrir el archivo exportado?", "Abrir archivo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (abrirArchivo == DialogResult.Yes)
                            {
                                //Usar ProcessStartInfo para abrir el archivo
                                var startInfo = new System.Diagnostics.ProcessStartInfo
                                {
                                    FileName = saveFileDialog.FileName,
                                    UseShellExecute = true
                                };
                                System.Diagnostics.Process.Start(startInfo);
                            }
                        }
                        else
                        {
                            MessageBox.Show("No se encontratron estudiantes para exportar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MessageBox.Show("Error al exportar a Excel.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportarExcel_Click(object sender, EventArgs e)
        {
            ImportarExcel();
        }
    }
}

