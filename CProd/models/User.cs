using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace CProd;
/// <summary>
/// Пользователь
/// </summary>
public partial class User
{
    /// <summary>
    /// Ид пользоватлея
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string Username { get; set; } = null!;
    /// <summary>
    /// Пароль
    /// </summary>
    public string PasswordUser { get; set; } = null!;
    /// <summary>
    /// Роль
    /// </summary>
    public string RoleUser { get; set; } = null!;
    /// <summary>
    /// Почта
    /// </summary>
    public string? Email { get; set; }
}
