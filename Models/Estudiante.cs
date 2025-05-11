using System;
using System.Collections.Generic;

namespace PlataformaEvaluacion.Models;

public partial class Estudiante
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Correo { get; set; }

    public virtual ICollection<Incripcione> Incripciones { get; set; } = new List<Incripcione>();

    public virtual ICollection<Resultado> Resultados { get; set; } = new List<Resultado>();
}
