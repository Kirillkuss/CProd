
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CProd;
/// <summary>
/// Пациент
/// </summary>
public partial class Patient{

    /// <summary>
    /// Ид пациента
    /// </summary>
    [DefaultValue("1")]
    public int IdPatient { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    [DefaultValue("Петров")]
    public string Surname { get; set; } = null!;
    /// <summary>
    /// Имя
    /// </summary>
    [DefaultValue("Петр")]
    public string Name { get; set; }  = null!;
    /// <summary>
    /// Отчество
    /// </summary>
    [DefaultValue("Петрович")]
    public string FullName { get; set; } = null!;
    /// <summary>
    /// Пол
    /// </summary>
    //[DefaultValue("1")]
    public Gender? Gender { get; set; }
    /// <summary>
    /// Номер телефона
    /// </summary>
    [DefaultValue("+375297834312")]
    public string Phone { get; set; } = null!;
    /// <summary>
    /// Адрес
    /// </summary>
    [DefaultValue("Проспект Мирный д.10 ув. 3")]
    public string Address { get; set; } = null!;
     [ScaffoldColumn(false)] 
    public int Document_id;
    /// <summary>
    /// Документ
    /// </summary>
    public virtual Document? Document { get; set;}

    public override string ToString()
    {
        return "{\n"
                + " IdPatient=" + IdPatient 
                + ",\n Surname=" + Surname
                + ",\n Name=" + Name 
                + ",\n FullName=" + FullName
                + ",\n Gender=" + Gender
                + ",\n Phone=" + Phone
                + ",\n Address=" + Address
                + ",\n Document=" + Document
                +"\n}";
    }
 }


