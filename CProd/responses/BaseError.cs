using System.ComponentModel;

namespace CProd;
/// <summary>
/// Ошибка
/// </summary>
class BaseError{

    /// <summary>
    /// Код
    /// </summary>
    [DefaultValue("404")]
    public int code { get; set; } = 404;

    /// <summary>
    /// Сообщение
    /// </summary>
    [DefaultValue("Ошибка")]
    public string message { get; set; } = "Error"; 

    public BaseError( int code, string message ){
        this.code = code;
        this.message = message;
    }
}