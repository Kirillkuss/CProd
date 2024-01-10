
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Медикаментозное лечение
/// </summary>
public partial class DrugTreatment{
    /// <summary>
    /// ИД
    /// </summary>
    [DefaultValue("100")]
    public int IdDrugTreatment { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    [DefaultValue("Кортикостероиды")]
    public string Name { get; set; } = null!;
}
