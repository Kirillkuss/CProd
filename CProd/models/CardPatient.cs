
namespace CProd;

public partial class CardPatient
{
    public int IdCardPatient { get; set; }

    public string Diagnosis { get; set; } = null!;

    public bool Allergy { get; set; }

    public string? Note { get; set; }

    public string? Сonclusion { get; set; }

    public int PatientId;

    public virtual Patient Patient { get; set; } = null!;

    public virtual ICollection<TypeComplaint> TypeComplaints { get; set; } = new List<TypeComplaint>();

}
