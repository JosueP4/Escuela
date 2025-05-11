using System;
using System.Collections.Generic;

namespace PlataformaEvaluacion.Models;

public partial class Examene
{
    public int Id { get; set; }

    public int? CursoId { get; set; }

    public string? Titulo { get; set; }

    public virtual Curso? Curso { get; set; }

    public virtual ICollection<Pregunta> Pregunta { get; set; } = new List<Pregunta>();

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
