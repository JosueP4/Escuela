using System;
using System.Collections.Generic;

namespace PlataformaEvaluacion.Models;

public partial class Curso
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Examene> Examenes { get; set; } = new List<Examene>();

    public virtual ICollection<Incripcione> Incripciones { get; set; } = new List<Incripcione>();
}
