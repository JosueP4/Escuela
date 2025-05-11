namespace PlataformaEvaluacion.DTOs
{
    public class IncripcionesDTO
    {
        public int Id { get; set; }

        public int? EstudianteId { get; set; }

        public int? CursoId { get; set; }

        public DateTime? FechaIncripcion { get; set; }
    }
}
