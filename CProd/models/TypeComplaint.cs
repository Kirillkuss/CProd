namespace CProd;

public partial class TypeComplaint{

    public int IdTypeComplaint { get; set; }

    public string name { get; set;} = null!;

    public Complaint? Complaint;
}