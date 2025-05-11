using System;
using System.Collections.Generic;

namespace PlataformaEvaluacion.Models;

public partial class Resultado
{
    public int Id { get; set; }

    public int? ExamenId { get; set; }

    public int? EstudianteId { get; set; }

    public int? Calificacion { get; set; }

    public DateTime? FechaPresentacion { get; set; }

    public virtual Estudiante? Estudiante { get; set; }

    public virtual Examene? Examen { get; set; }
}
