
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Реабилитационное лечение
/// </summary>
public partial class RehabilitationSolution{
    /// <summary>
    /// ИД
    /// </summary>
    [DefaultValue("100")]
    public int IdRehabilitationSolution { get; set; }
    /// <summary>
    /// Наименование
    /// </summary>
    [DefaultValue("Кинезитерапия")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// План обследования
    /// </summary>
    [DefaultValue("План реабилитационного лечения")]
    public string SurveyPlan { get; set; } = null!;
}
