using System.ComponentModel;
namespace CProd;
/// <summary>
/// Пользователь
/// </summary>
public partial class User
{
    /// <summary>
    /// Ид пользоватлея
    /// </summary>
    [DefaultValue("1")]
    public int Id { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    [DefaultValue("user")]
    public string Username { get; set; } = null!;
    /// <summary>
    /// Пароль
    /// </summary>
    [DefaultValue("password")]
    public string PasswordUser { get; set; } = null!;
    /// <summary>
    /// Роль
    /// </summary>
    [DefaultValue("Admin")]
    public string RoleUser { get; set; } = null!;
    /// <summary>
    /// Почта
    /// </summary>
    [DefaultValue("admin@mail.com")]
    public string? Email { get; set; }
}
