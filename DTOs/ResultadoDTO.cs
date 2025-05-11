namespace PlataformaEvaluacion.DTOs
{
    public class ResultadoDTO
    {
        public int Id { get; set; }

        public int? ExamenId { get; set; }

        public int? EstudianteId { get; set; }

        public int? Calificacion { get; set; }

        public DateTime? FechaPresentacion { get; set; }
    }
}
