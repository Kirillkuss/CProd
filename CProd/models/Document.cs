using System;
using System.Collections.Generic;

namespace CProd;

public partial class Document
{
    public int IdDocument { get; set; }

    public string TypeDocument { get; set; } = null!;

    public string Seria { get; set; } = null!;

    public string Numar { get; set; } = null!;

    public string? Snils { get; set; }

    public string? Polis { get; set; }

   // public virtual Patient? Patient { get; set; }
}
