
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Лекарство 
/// </summary>
public partial class Drug{
    /// <summary>
    /// ИД
    /// </summary>
    [DefaultValue("100")]
    public int IdDrug { get; set; }
    /// <summary>
    /// Препараты
    /// </summary>
    [DefaultValue("Карвалол 2 чайные ложки в день")]
    public string Name { get; set; } = null!;
    public int DrugTreatmentId;
    /// <summary>
    /// Медикаментозное лечение
    /// </summary>
    [DefaultValue("100")]
    public virtual DrugTreatment DrugTreatment { get; set; } = null!;
}
