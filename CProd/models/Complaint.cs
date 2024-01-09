using System;
using System.Collections.Generic;

namespace CProd;

public partial class Complaint
{
    public int IdComplaint { get; set; }

    public string FunctionalImpairment { get; set; } = null!;

    public virtual ICollection<TypeComplaint> TypeComplaints { get; set; } = new List<TypeComplaint>();
}
