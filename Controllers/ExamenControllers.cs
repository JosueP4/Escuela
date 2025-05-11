using Microsoft.AspNetCore.Mvc;
using PlataformaEvaluacion.DTOs;
using PlataformaEvaluacion.Services;

namespace PlataformaEvaluacion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamenControllers : ControllerBase
    {
        private readonly ExamenesServices _service;

        public ExamenControllers(ExamenesServices examenesServices)
        {
             _service = examenesServices;
        }
        [HttpPost("CrearExamen")]
        public async Task<ActionResult> CrearExamen(ExamenesDTO examenesDTO)
        {
            ExamenesDTO examen = await _service.CrearExamen(examenesDTO);
            return Ok(examen);
        }
    }
}
