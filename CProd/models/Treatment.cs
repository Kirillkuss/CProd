
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Лечение
/// </summary>
public partial class Treatment{
    /// <summary>
    /// ИД
    /// </summary>
    [DefaultValue("100")]
    public int IdTreatment { get; set; }
    /// <summary>
    /// Дата начала лечения 
    /// </summary>
    [DefaultValue("2024-01-10T14:08:25.297")]
    public DateTime TimeStartTreatment { get; set; }
    /// <summary>
    /// Дата окончания лечения
    /// </summary>
    [DefaultValue("2024-07-10T14:08:25.297")]
    public DateTime EndTimeTreatment { get; set; }

    public int DrugId;
    /// <summary>
    /// ИД пациента
    /// </summary>
    public int CardPatientId { get; set; }

    public int DoctorId;

    public int RehabilitationSolutionId;
    /// <summary>
    /// Доктор
    /// </summary>
    public virtual Doctor Doctor { get; set; } = null!;
    /// <summary>
    /// Медикаментозное лечение
    /// </summary>
    public virtual Drug Drug { get; set; } = null!;
    /// <summary>
    /// Реабилитационное лечение
    /// </summary>
    public virtual RehabilitationSolution RehabilitationSolution { get; set; } = null!;
}
