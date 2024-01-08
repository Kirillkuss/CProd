namespace CProd;

public partial class Drug{

    public int IdDrug { get; set; }

    public string Name { get; set; } = null!;

    public DrugTreatment? DrugTreatment { get; set; }
}