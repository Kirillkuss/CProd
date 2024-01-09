
namespace CProd;

public partial class TypeComplaint{
    public int IdTypeComplaint { get; set; }

    public string Name { get; set; } = null!;

    public int ComplaintId;

    public virtual Complaint Complaint { get; set; } = new Complaint();

    public ICollection<CardPatient>? CardPatients;
}
