using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using PlataformaEvaluacion.DTOs;
using PlataformaEvaluacion.Services;

namespace PlataformaEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PreguntasController : ControllerBase
    {
        private readonly PreguntasService _service;

        public PreguntasController(PreguntasService preguntas)
        {
             _service = preguntas;

        }
        [HttpPost("CrearPreguntas")]
        public async Task<ActionResult> CrearPreguntas(PreguntaDTO preguntaDTO, int examenId)
        {
            PreguntaDTO preguntas = await _service.CrearPreguntas(preguntaDTO, examenId);
            return Ok(preguntas);
        }
        [HttpGet("BuscarExamen")]
        public async Task<ActionResult> BuscarExamen(int id)
        {
            PreguntaDTO preguntas = await _service.BuscarExamen(id);
            return Ok(preguntas);
        }
    }
}
