
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Карта пациента
/// </summary>
public partial class CardPatient{
    /// <summary>
    /// ИД карты пациента
    /// </summary>
    [DefaultValue("100")]
    public int IdCardPatient { get; set; }
    /// <summary>
    /// Диагноз
    /// </summary>
    [DefaultValue("Рассеянный склероз")]
    public string Diagnosis { get; set; } = null!;
    /// <summary>
    /// Аллергия
    /// </summary>
    [DefaultValue("Аллергия на препараты")]
    public bool Allergy { get; set; }
    /// <summary>
    /// Примечание
    /// </summary>
    [DefaultValue("Есть аллергия на цитрамон")]
    public string? Note { get; set; }
    /// <summary>
    /// Заключение
    /// </summary>
    [DefaultValue("Болен")]
    public string? Сonclusion { get; set; }
    public int PatientId;
    /// <summary>
    /// Пациент
    /// </summary>
    public virtual Patient Patient { get; set; } = null!;
    /// <summary>
    /// Список жалоб
    /// </summary>
    public virtual ICollection<TypeComplaint> TypeComplaints { get; set; } = new List<TypeComplaint>();

}
