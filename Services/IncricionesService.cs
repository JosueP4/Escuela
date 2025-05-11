using PlataformaEvaluacion.DTOs;
using PlataformaEvaluacion.Models;

namespace PlataformaEvaluacion.Services
{
    public class IncricionesService
    {
        private readonly PlataformaevaluacionContext _context;
        public IncricionesService(PlataformaevaluacionContext plataformaevaluacionContext)
        {
               _context = plataformaevaluacionContext;
        }

        public async Task<IncripcionesDTO> IncrisbirEstudiante(IncripcionesDTO incripcionesDTO)
        {
            var incripcion = new Incripcione
            {
                Id = incripcionesDTO.Id,
                EstudianteId = incripcionesDTO.EstudianteId,
                CursoId = incripcionesDTO.CursoId
            };

            _context.Incripciones.Add(incripcion);
            await _context.SaveChangesAsync();

            return new IncripcionesDTO
            {
                Id = incripcion.Id,
                EstudianteId = incripcion.EstudianteId,
                CursoId = incripcion.CursoId,
                FechaIncripcion = incripcion.FechaIncripcion
            };
        }

        public async Task<IncripcionesDTO> IncristoCurso(int cursoId)
        {
            var incripcion = await _context.Incripciones.FindAsync(cursoId);
            if (incripcion == null) return null;

            return new IncripcionesDTO
            {
                Id = incripcion.Id,
                EstudianteId = incripcion.EstudianteId,
                CursoId = incripcion.CursoId
            };
        }
    }
}
