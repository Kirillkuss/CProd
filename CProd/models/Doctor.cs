using System.ComponentModel;

namespace CProd;
/// <summary>
/// Доктор
/// </summary>
public partial class Doctor{
    /// <summary>
    /// ИД
    /// </summary>
    [DefaultValue("100")]
    public int IdDoctor { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    [DefaultValue("Petrov")]
    public string Surname { get; set; } = null!;
    /// <summary>
    /// Имя
    /// </summary>
    [DefaultValue("Petr")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// Отчество
    /// </summary>
    [DefaultValue("Petrovich")]
    public string FullName { get; set; } = null!;

}
