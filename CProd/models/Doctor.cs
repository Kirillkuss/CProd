using System;
using System.Collections.Generic;

namespace CProd;

public partial class Doctor
{
    public int IdDoctor { get; set; }

    public string Surname { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FullName { get; set; } = null!;

   // public virtual ICollection<RecordPatient> RecordPatients { get; set; } = new List<RecordPatient>();

    //public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}
