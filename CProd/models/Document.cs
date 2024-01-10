
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Документ
/// </summary>
public partial class Document{
    /// <summary>
    /// ИД
    /// </summary>
    [DefaultValue("100")]
    public int IdDocument { get; set; }
    /// <summary>
    /// Тип документа
    /// </summary>
    [DefaultValue("Паспорт")]
    public string TypeDocument { get; set; } = null!;
    /// <summary>
    /// Серия документа
    /// </summary>
    [DefaultValue("ВМ")]
    public string Seria { get; set; } = null!;
    /// <summary>
    /// Номер документа
    /// </summary>
    [DefaultValue("123243455")]
    public string Numar { get; set; } = null!;
    /// <summary>
    /// СНИЛС
    /// </summary>
    [DefaultValue("123-456-789-01")]
    public string? Snils { get; set; }
    /// <summary>
    /// Полис
    /// </summary>
    [DefaultValue("0000 0000 0000 0000")]
    public string? Polis { get; set; }
}
