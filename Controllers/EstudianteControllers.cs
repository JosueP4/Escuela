using Microsoft.AspNetCore.Mvc;
using PlataformaEvaluacion.DTOs;
using PlataformaEvaluacion.Services;

namespace PlataformaEvaluacion.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteControllers : ControllerBase
    {
        private readonly EstudianteService _services;

        public EstudianteControllers(EstudianteService estudianteService)
        {
             _services = estudianteService;
        }
        [HttpPost("CrearEstudiante")]
        public async Task<ActionResult> CrearEstudiante(EstudianteDTO estudianteDTO)
        {
            EstudianteDTO estudiante = await _services.CrearEstudiante(estudianteDTO);
            return Ok(estudiante);
        }

        [HttpGet("ListaEstudiantes")]
        public async Task<ActionResult<List<EstudianteDTO>>> ListaEstudiantes()
        {
            List<EstudianteDTO> estudiante = await _services.ListaEstudiantes();
            return Ok(estudiante);
        }
    }
}
