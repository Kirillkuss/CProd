using CProd;

namespace CProod;

public partial class Treatment{

    public int IdTreatment { get; set; }

    public DateTime TimeStartTreatment { get; set;}

    public DateTime EndTimeTreatment { get; set; }

    public int DrugId;

    public Drug? Drug { get; set; } = new Drug();

    public int RehabilitationSolutionId;

    public RehabilitationSolution? RehabilitationSolution { get; set; } = new RehabilitationSolution();

    public int CardPatientId { get; set; }

    public int DoctorId;

    public Doctor? Doctor { get; set; } = new Doctor();
}