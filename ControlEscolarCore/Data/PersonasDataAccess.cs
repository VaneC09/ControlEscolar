using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NpgsqlTypes;
using NLog;
using ControlEscolarCore.Utilities;
using ControlEscolarCore.Model;


namespace ControlEscolarCore.Data
{
    /// <summary> 
    /// Clase que maneja las operaciones de acceso a datos para la entidad Personas 
    /// en la tabla seguridad personas de PostgreSQL. 
    /// </summary> 
    public class PersonasDataAccess
    {
        //Logger usando el LoggingManager
        private static readonly Logger _logger = LoggingManager.GetLogger("ControlEscolar.Data.PersonasDataAccess");

        private readonly PostgreSQLDataAccess _dbAccess = null;

        public PersonasDataAccess()
        {
            try
            {
                //Obtener instancia de PosgresSQLAccess atraves de su método GetInstance
                _dbAccess = PostgreSQLDataAccess.GetInstance();
            }
            catch
            {
                _logger.Error("Error al intentar crear instancia de PersonasDataAccess");
                throw;
            }
        }

        public int InsertarPersona(Persona personas)
        {
            try
            {
                string query = @"
                    INSERT INTO seguridad.personas (nombre_completo, correo, telefono, fecha_nacimiento, curp, estatus)
                    VALUES (@nombreCompleto, @correo, @telefono, @fechaNacimiento, @curp, @estatus)
                    RETURNING id;";

                //Crear los parámetros
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@nombreCompleto", personas.NombreCompleto);
                NpgsqlParameter paramCorreo = _dbAccess.CreateParameter("@correo", personas.Correo);
                NpgsqlParameter paramTelefono = _dbAccess.CreateParameter("@telefono", personas.Telefono);
                NpgsqlParameter paramFechaNac = _dbAccess.CreateParameter("@FechaNacimiento", personas.FechaNacimiento ?? (object)DBNull.Value);
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@curp", personas.Curp);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@estatus", personas.Estatus);

                //Conexion
                _dbAccess.Connect();

                //Ejecutar la consulta, con ExecuteScalar que es para obtener un solo valor de la consulta 
                object? resultado = _dbAccess.ExecuteScalar(query, paramNombre, paramCorreo, paramTelefono, paramFechaNac, paramCurp, paramEstatus);

                //convertir el resulado en entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Persona insertada con ID: {idGenerado}");

                return idGenerado;

            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar persona {personas.NombreCompleto}");
                return -1;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si existe un CURP en la base de datos
        /// </summary>
        /// <param name="curp">CURP a verificar</param>
        /// <returns>True si existe, False si no existe</returns>
        public bool ExisteCurp(string curp)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM seguridad.personas WHERE curp = @Curp";
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", curp);
                _dbAccess.Connect();
                object? resultado = _dbAccess.ExecuteScalar(query, paramCurp);
                int count = Convert.ToInt32(resultado);
                return count > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia del CURP: {curp}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public bool ActualizarPersona(Persona persona)
        {
            try
            {
                string query = "UPDATE seguridad.personas " +
                               "SET nombre_completo = @NombreCompleto, " +
                               "    correo = @Correo, " +
                               "    telefono = @Telefono, " +
                               "    fecha_nacimiento = @FechaNacimiento, " +
                               "    curp = @Curp, " +
                               "    estatus = @Estatus " +
                               "WHERE id = @Id";

                // Crea los parámetros
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@Id", persona.Id);
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramCorreo = _dbAccess.CreateParameter("@Correo", persona.Correo);
                NpgsqlParameter paramTelefono = _dbAccess.CreateParameter("@Telefono", persona.Telefono);
                NpgsqlParameter paramFechaNac = _dbAccess.CreateParameter("@FechaNacimiento", persona.FechaNacimiento ?? (object)DBNull.Value);
                NpgsqlParameter paramCurp = _dbAccess.CreateParameter("@Curp", persona.Curp);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", persona.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId, paramNombre, paramCorreo,
                                                                paramTelefono, paramFechaNac, paramCurp, paramEstatus);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Persona con ID {persona.Id} actualizada correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar la persona con ID {persona.Id}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar la persona con ID {persona.Id}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

    }
}
