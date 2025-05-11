namespace PlataformaEvaluacion.DTOs
{
    public class PreguntaDTO
    {
        public int Id { get; set; }

        public int? ExamenId { get; set; }

        public string? Pregunta1 { get; set; }

        public string? Opciones { get; set; }

        public string? RepuestaCorrecta { get; set; }

    }
}
