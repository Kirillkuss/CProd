
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Пациент
/// </summary>
public partial class Patient{
    /// <summary>
    /// ИД
    /// </summary>
    [DefaultValue("100")]
    public int IdPatient { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    [DefaultValue("Пупкин")]
    public string Surname { get; set; } = null!;
    /// <summary>
    /// Имя
    /// </summary>
    [DefaultValue("Петр")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// Отчество
    /// </summary>
    [DefaultValue("Петрович")]
    public string FullName { get; set; } = null!;
    /// <summary>
    /// Пол
    /// </summary>
    [DefaultValue("1")]
    public short Gender { get; set; }
    /// <summary>
    /// Номер телефона
    /// </summary>
    [DefaultValue("+375297562316")]
    public string Phone { get; set; } = null!;
    /// <summary>
    /// Адрес
    /// </summary>
    [DefaultValue("Московская 31 к.1 ")]
    public string Address { get; set; } = null!;

    public int? DocumentId;
    /// <summary>
    /// Документ
    /// </summary>
    
    public virtual Document? Document { get; set; }
}
