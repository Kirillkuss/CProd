using CProd;

namespace CProod;

public partial class Treatment{

    public int IdTreatment { get; set; }

    public DateTime TimeStartTreatment { get; set;}

    public DateTime EndTimeTreatment { get; set; }

    public Drug? Drug { get; set; }

    public RehabilitationSolution? RehabilitationSolution { get; set; }

    public int CardPatientId { get; set; }

    public Doctor? Doctor { get; set; }
}