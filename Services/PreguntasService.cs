using PlataformaEvaluacion.DTOs;
using PlataformaEvaluacion.Models;

namespace PlataformaEvaluacion.Services
{
    public class PreguntasService
    {
        private readonly PlataformaevaluacionContext _context;
        public PreguntasService(PlataformaevaluacionContext plataformaevaluacionContext)
        {
            _context = plataformaevaluacionContext;
        }

        public async Task<PreguntaDTO> CrearPreguntas(PreguntaDTO preguntaDTO, int examenId)
        {
            var pregunta = await _context.Preguntas.FindAsync(examenId);
            if (pregunta == null) return null;

            var preguntas = new Pregunta
            {
                Id = preguntaDTO.Id,
                ExamenId = preguntaDTO.ExamenId,
                Pregunta1 = preguntaDTO.Pregunta1,
                Opciones = preguntaDTO.Opciones,
                RepuestaCorrecta = preguntaDTO.RepuestaCorrecta
            };

            _context.Preguntas.Add(preguntas);
            await _context.SaveChangesAsync();

            return new PreguntaDTO
            {
                Id = preguntas.Id,
                ExamenId = preguntas.ExamenId,
                Pregunta1 = preguntas.Pregunta1,
                Opciones = preguntas.Opciones,
            };
        }

        public async Task<PreguntaDTO> BuscarExamen(int id)
        {
            var preguntas = await _context.Preguntas.FindAsync(id);
            if (preguntas is null) return null;

            return new PreguntaDTO
            {
                Id = preguntas.Id,
                ExamenId = preguntas.ExamenId,
                Pregunta1 = preguntas.Pregunta1,
                Opciones = preguntas.Opciones,
            };
        }
    }
}
