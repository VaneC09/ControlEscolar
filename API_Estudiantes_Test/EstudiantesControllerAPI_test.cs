using ControlEscolarCore.Controller;
using ControlEscolarCore.Model;
using Microsoft.AspNetCore.Mvc;



namespace API_Estudiantes_Test
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstudiantesControllerAPI_Test : ControllerBase
    {
        private readonly EstudiantesController _estudiantesController;
        private readonly ILogger<EstudiantesControllerAPI_Test> _logger;

        public EstudiantesControllerAPI_Test(EstudiantesController estudiantesController, ILogger<EstudiantesControllerAPI_Test> logger)
        {
            _estudiantesController = estudiantesController;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los estudiantes con filtros opcionales
        /// </summary>
        /// <param name="soloActivos">Filtrar solo estudiantes activos</param>
        /// <param name="tipoFecha">1=Fecha nacimiento, 2=Fecha alta, 3=Fecha baja</param>
        /// <param name="fechaInicio">Fecha inicial del rango</param>
        /// <param name="fechaFin">Fecha final del rango</param>
        /// <returns>Lista de estudiantes</returns>
        [HttpGet("list_estudiantes")]  // Ahora tiene una ruta específica
        
        public IActionResult GetEstudiantes(
            [FromQuery] bool soloActivos = true,
            [FromQuery] int tipoFecha = 0,
            [FromQuery] DateTime? fechaInicio = null,
            [FromQuery] DateTime? fechaFin = null)
        {
            try
            {
                var estudiantes = _estudiantesController.ObtenerTodosLosEstudiantes(
                    soloActivos,
                    tipoFecha,
                    fechaInicio,
                    fechaFin);

                return Ok(estudiantes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener estudiantes");
                return StatusCode(500, "Error interno del servidor" + ex.Message);
            }
        }


        /// <summary>
        /// Actualiza los datos de un estudiante existente.
        /// </summary>
        /// <param name="idestudiante">Identificador del estudiante</param>
        /// <returns>Resultado de la operación</returns>
        [HttpPut("actualizar_nombreestudiante")]
        public IActionResult ActualizarEstudiante([FromQuery] int idestudiante, [FromQuery] string nuevo_nombre)
        {
            try
            {
                var resultado = _estudiantesController.ActualizarNombreEstudiante(idestudiante, nuevo_nombre);

                if (resultado.exito)
                    return Ok(new { mensaje = resultado.mensaje });
                else
                    return BadRequest(new { mensaje = resultado.mensaje });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar estudiante");
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }


    }
}
