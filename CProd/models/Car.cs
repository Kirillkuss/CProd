using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Машина
/// </summary>
public partial class Car
{
    /// <summary>
    /// Ид машины
    /// </summary>
    [DefaultValue("1")]
    public int Id { get; set; }
    /// <summary>
    /// Модель
    /// </summary>
    [DefaultValue("Tesla")]
    public string Model { get; set; } = null!;
    /// <summary>
    /// Время покупки
    /// </summary>
    [DefaultValue("2023-04-11T09:21:38.499")]
    public DateTime? Timebuy { get; set; }
    /// <summary>
    /// Цена
    /// </summary>
    [DefaultValue("89000")]
    public long Coast { get; set; }
    /// <summary>
    /// Номер
    /// </summary>
    [DefaultValue("0450")]
    public int Number { get; set; }
}
