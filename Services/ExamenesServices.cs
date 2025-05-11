using PlataformaEvaluacion.DTOs;
using PlataformaEvaluacion.Models;

namespace PlataformaEvaluacion.Services
{
    public class ExamenesServices
    {
        private readonly PlataformaevaluacionContext _context;
        public ExamenesServices(PlataformaevaluacionContext context)
        {
             _context = context;
        }

        public async Task<ExamenesDTO> CrearExamen(ExamenesDTO examenesDTO)
        {
            var examen = new Examene
            {
                Id = examenesDTO.Id,
                CursoId = examenesDTO.CursoId,
                Titulo = examenesDTO.Titulo
            };

            _context.Examenes.Add(examen);
            await _context.SaveChangesAsync();

            return new ExamenesDTO
            {
                Id = examen.Id,
                CursoId = examen.CursoId,
                Titulo = examen.Titulo
            };
        }
    }
}
