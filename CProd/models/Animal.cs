using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace CProd;
/// <summary>
/// Питомец
/// </summary>
public partial class Animal
{
    /// <summary>
    /// Ид питомца
    /// </summary>
    [DefaultValue("1")]
    public int Id { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    [DefaultValue("cat")]
    public string Name { get; set; } = null!;
    /// <summary>
    /// цена
    /// </summary>
    [DefaultValue("2300")]
    public long Amount { get; set; }
    /// <summary>
    /// Количество
    /// </summary>
    [DefaultValue("10")]
    public int? Count { get; set; }
}
