using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Writers;
using PlataformaEvaluacion.DTOs;
using PlataformaEvaluacion.Models;

namespace PlataformaEvaluacion.Services
{
    public class EstudianteService
    {
        private readonly PlataformaevaluacionContext _Context;
        public EstudianteService(PlataformaevaluacionContext plataformaevaluacionContext)
        {

            _Context = plataformaevaluacionContext;
        }

        public async Task<EstudianteDTO> CrearEstudiante(EstudianteDTO estudianteDTO)
        {
            var estudiante = new Estudiante
            {
                Id = estudianteDTO.Id,  
                Nombre = estudianteDTO.Nombre,
                Correo = estudianteDTO.Correo
            };

            _Context.Estudiantes.Add(estudiante);
            await _Context.SaveChangesAsync();

            return new EstudianteDTO
            {
                Id = estudiante.Id,
                Nombre = estudiante.Nombre,
                Correo = estudiante.Correo
            };
        }

        public async Task<List<EstudianteDTO>> ListaEstudiantes()
        {
            var estudiante = await _Context.Estudiantes.ToListAsync();

            List<EstudianteDTO> estudianteList = new List<EstudianteDTO>();

            foreach(var item in estudiante)
            {
                var estudiante1 = new EstudianteDTO
                {
                    Id=item.Id,
                    Nombre = item.Nombre,
                    Correo = item.Correo
                };

                estudianteList.Add(estudiante1);
            };

            return estudianteList;
        }
    }
}
