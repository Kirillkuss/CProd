using System;
using System.Collections.Generic;

namespace CProd;

public partial class TypeComplaint
{
    public int IdTypeComplaint { get; set; }

    public string Name { get; set; } = null!;

    public int ComplaintId { get; set; }

    public virtual Complaint Complaint { get; set; } = null!;

    public virtual ICollection<CardPatient> CardPatients { get; set; } = new List<CardPatient>();
}
