using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlataformaEvaluacion.DTOs;
using PlataformaEvaluacion.Services;

namespace PlataformaEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoControllers :ControllerBase
    {
        private readonly CursoService _service;
        public CursoControllers(CursoService cursoService)
        {
             _service = cursoService;
        }
        [HttpPost("CrearCurso")]
        public async Task<ActionResult> CrearCurso(CursoDTO cursoDTO)
        {
            CursoDTO curso = await _service.CrearCurso(cursoDTO);
            return Ok(curso);
        }

        [HttpGet("ListaCurso")]
        public async Task<ActionResult<List<CursoDTO>>> ListaCurso()
        {
            List<CursoDTO> curso = await _service.ListaCurso();
            return Ok(curso);
        }
    }
}
