using System;
using System.Collections.Generic;

namespace PlataformaEvaluacion.Models;

public partial class Incripcione
{
    public int Id { get; set; }

    public int? EstudianteId { get; set; }

    public int? CursoId { get; set; }

    public DateTime? FechaIncripcion { get; set; }

    public virtual Curso? Curso { get; set; }

    public virtual Estudiante? Estudiante { get; set; }
}
