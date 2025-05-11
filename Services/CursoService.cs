using Microsoft.EntityFrameworkCore;
using PlataformaEvaluacion.DTOs;
using PlataformaEvaluacion.Models;

namespace PlataformaEvaluacion.Services
{
    public class CursoService
    {

        private readonly PlataformaevaluacionContext _context;
        public CursoService(PlataformaevaluacionContext plataformaevaluacionContext)
        {

            _context = plataformaevaluacionContext;
        }

        public async Task<CursoDTO> CrearCurso(CursoDTO cursoDTO)
        {
            var curso = new Curso
            {
                Id = cursoDTO.Id,
                Nombre = cursoDTO.Nombre,
                Descripcion = cursoDTO.Descripcion
            };

            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return new CursoDTO
            {
                Id = curso.Id,
                Nombre = curso.Nombre,
                Descripcion = curso.Descripcion
            };
        }

        public async Task<List<CursoDTO>> ListaCurso()
        {
            var curso = await _context.Cursos.ToListAsync();
            List<CursoDTO> cursoList = new List<CursoDTO>();

            foreach(var item in curso)
            {
                var curso1 = new CursoDTO
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion

                };

                cursoList.Add(curso1);
            };

            return cursoList;
        }
    }
}
