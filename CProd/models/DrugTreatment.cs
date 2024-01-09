using System.ComponentModel;

namespace CProd;
/// <summary>
/// Медикаментозное леяение
/// </summary>
public partial class DrugTreatment{
    /// <summary>
    /// Ид медикаментозное лечение
    /// </summary>
    [DefaultValue("1")]
    public int IdDrugTreatment { get; set; } 
    /// <summary>
    /// Наименование медикоментозного лечения
    /// </summary>
    [DefaultValue("Наименование")]
    public string Name { get; set; } = null!;

    public override string ToString()
    {
        return "{\n"
                + " IdDrugTreatment=" + IdDrugTreatment 
                + ",\n Name=" + Name
                +"\n}";
    }
}