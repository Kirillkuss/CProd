namespace CProd;

public partial class CardPatient{

    public int IdCardPatient { get; set; }

    public string Diagnosis { get; set; } = null!;

    public bool Allergy { get; set; }

    public string Note { get; set; } = null!;

    public string Conclusion { get; set; } = null!;

    //public List<TypeComplaint>? TypeComplaint { get; set; }

    public  Patient? Patient { get; set; }
}