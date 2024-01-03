using System;
using System.Collections.Generic;

namespace CProd;
/// <summary>
/// Машина
/// </summary>
public partial class Car
{
    /// <summary>
    /// Ид машины
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Модель
    /// </summary>
    public string Model { get; set; } = null!;
    /// <summary>
    /// Время покупки
    /// </summary>
    public DateTime? Timebuy { get; set; }
    /// <summary>
    /// Цена
    /// </summary>
    public long Coast { get; set; }
    /// <summary>
    /// Номер
    /// </summary>
    public int Number { get; set; }
}
