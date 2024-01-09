using System.ComponentModel;

namespace CProd;
/// <summary>
/// Лекарство
/// </summary>
public partial class Drug{
    /// <summary>
    /// Ид лекарства
    /// </summary>
    [DefaultValue("1")]
    public int IdDrug { get; set; }
    /// <summary>
    /// Название лекарства
    /// </summary>
    [DefaultValue("Препарат")]
    public string Name { get; set; } = null!;

    public int DrugTreatmentId;
    /// <summary>
    /// Медикаментозное лечение
    /// </summary>
    public DrugTreatment DrugTreatment { get; set; } = new DrugTreatment();

    public override string ToString()
    {
        return "{\n"
                + " IdDrug=" + IdDrug 
                + ",\n IdDrug=" + IdDrug
                + ",\n DrugTreatment=" + DrugTreatment 
                +"\n}";
    }
}