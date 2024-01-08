using System.ComponentModel;

namespace CProd;

/// <summary>
/// Документ
/// </summary>
public partial class Document{
    /// <summary>
    /// Ид документа
    /// </summary>
    [DefaultValue("1")]
    public int IdDocument {get; set;}
    /// <summary>
    /// Тип документа
    /// </summary>
    [DefaultValue("Паспорт")]
    public string TypeDocument { get; set; } = null!;
    /// <summary>
    /// Серия
    /// </summary>
    [DefaultValue("ВМ")]
    public string Seria { get; set; } = null!;
    /// <summary>
    /// Номер
    /// </summary>
    [DefaultValue("3434121")]
    public string Numar { get; set; } = null!;
    /// <summary>
    /// Снилс
    /// </summary>
    [DefaultValue("123-456-789-11")]
    public string Snils { get; set; } = null!;
    /// <summary>
    /// Полис
    /// </summary>
    [DefaultValue("0000 0000 0000 2000")]
    public string Polis { get; set; } = null!;

    
    public override string ToString()
    {
        return "{\n"
                + " IdDocument=" + IdDocument 
                + ",\n TypeDocument=" + TypeDocument
                + ",\n Seria=" + Seria 
                + ",\n Numar=" + Numar
                + ",\n Snils=" + Snils
                + ",\n Polis=" + Polis
                +"\n}";
    }

}