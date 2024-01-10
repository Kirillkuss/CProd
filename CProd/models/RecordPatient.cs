
using System.ComponentModel;

namespace CProd;
 /// <summary>
/// Запись пациента
/// </summary>
public partial class RecordPatient{
    /// <summary>
    /// ИД
    /// </summary>
    [DefaultValue("100")]
    public int IdRecord { get; set; }
    /// <summary>
    /// Дата записи
    /// </summary>
    [DefaultValue("2022-02-19T12:00:00")]
    public DateTime DateRecord { get; set; }
    /// <summary>
    /// Дата приема
    /// </summary>
    [DefaultValue("2022-03-01T15:00:00")]
    public DateTime DateAppointment { get; set; }
    /// <summary>
    /// Кабинет
    /// </summary>
    [DefaultValue("100")]
    public int NumberRoom { get; set; }

    public int DoctorId;
    /// <summary>
    /// ИД карты пациента
    /// </summary>
    [DefaultValue("12")]
    public int CardPatientId { get; set; }
    /// <summary>
    /// Доктор
    /// </summary>
    public virtual Doctor Doctor { get; set; } = null!;
}
