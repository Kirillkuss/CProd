using System;
using System.Collections.Generic;

namespace CProd;

public partial class RehabilitationSolution
{
    public int IdRehabilitationSolution { get; set; }

    public string Name { get; set; } = null!;

    public string SurveyPlan { get; set; } = null!;

    //public virtual ICollection<Treatment> Treatments { get; set; } = new List<Treatment>();
}
