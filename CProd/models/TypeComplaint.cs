
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Под жалоба
/// </summary>
public partial class TypeComplaint{
    /// <summary>
    /// ИД
    /// </summary>
    [DefaultValue("100")]
    public int IdTypeComplaint { get; set; }
    /// <summary>
    /// Наименование под жалобы
    /// </summary>
    [DefaultValue("Наименование под жалобы")]
    public string Name { get; set; } = null!;

    public int ComplaintId;
    /// <summary>
    /// Жалоба
    /// </summary>
    public virtual Complaint Complaint { get; set; } = new Complaint();

    public ICollection<CardPatient>? CardPatients;
}
