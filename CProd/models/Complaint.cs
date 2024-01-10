
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Жалоба
/// </summary>
public partial class Complaint{
    /// <summary>
    /// ИД жалобы
    /// </summary>
    [DefaultValue("100")]
    public int IdComplaint { get; set; }
    /// <summary>
    /// Наименование жалобы
    /// </summary>
    [DefaultValue("Симптомы поражения пирамидного тракта")]
    public string FunctionalImpairment { get; set; } = null!;

}
