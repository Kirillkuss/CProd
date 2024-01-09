using System;
using System.Collections.Generic;

namespace CProd;

public partial class Drug
{
    public int IdDrug { get; set; }

    public string Name { get; set; } = null!;

    public int DrugTreatmentId { get; set; }

    public virtual DrugTreatment DrugTreatment { get; set; } = null!;

    //public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}
