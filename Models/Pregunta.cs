using System;
using System.Collections.Generic;

namespace PlataformaEvaluacion.Models;

public partial class Pregunta
{
    public int Id { get; set; }

    public int? ExamenId { get; set; }

    public string? Pregunta1 { get; set; }

    public string? Opciones { get; set; }

    public string? RepuestaCorrecta { get; set; }

    public virtual Examene? Examen { get; set; }
}
