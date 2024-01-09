
namespace CProd;

public partial class Treatment{
    public int IdTreatment { get; set; }

    public DateTime TimeStartTreatment { get; set; }

    public DateTime EndTimeTreatment { get; set; }

    public int DrugId;

    public int CardPatientId { get; set; }

    public int DoctorId;

    public int RehabilitationSolutionId;

    public virtual Doctor Doctor { get; set; } = null!;

    public virtual Drug Drug { get; set; } = null!;

    public virtual RehabilitationSolution RehabilitationSolution { get; set; } = null!;
}
