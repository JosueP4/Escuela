using Microsoft.AspNetCore.Mvc;
using PlataformaEvaluacion.DTOs;
using PlataformaEvaluacion.Services;

namespace PlataformaEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncripcionesControllers : ControllerBase
    {
        private readonly IncricionesService _service;
        public IncripcionesControllers(IncricionesService incricionesService)
        {
            _service = incricionesService;
        }
        [HttpPost("IncrisbirEstudiante")]
        public async Task<ActionResult> IncrisbirEstudiante(IncripcionesDTO incripcionesDTO)
        {
            IncripcionesDTO incripcion = await _service.IncrisbirEstudiante(incripcionesDTO);
            return Ok(incripcion);
        }
        [HttpGet("IncristoCurso")]
        public async Task<ActionResult> IncristoCurso(int cursoId)
        {
            IncripcionesDTO incripcion = await _service.IncristoCurso(cursoId);
            return Ok(incripcion);
        }
    }
}
