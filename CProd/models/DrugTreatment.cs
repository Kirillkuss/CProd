using System;
using System.Collections.Generic;

namespace CProd;

public partial class DrugTreatment
{
    public int IdDrugTreatment { get; set; }

    public string Name { get; set; } = null!;

    //public virtual ICollection<Drug> Drugs { get; set; } = new List<Drug>();
}
