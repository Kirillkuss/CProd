using System;
using System.Collections.Generic;

namespace CProd;

public partial class Patient
{
    public int IdPatient { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public short Gender { get; set; }

    public string Phone { get; set; } = null!;

    public string Address { get; set; } = null!;

    public int? DocumentId;

    //public virtual CardPatient? CardPatient { get; set; }

    public virtual Document? Document { get; set; }
}
