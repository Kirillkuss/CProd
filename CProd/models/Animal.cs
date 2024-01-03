using System;
using System.Collections.Generic;

namespace CProd;
/// <summary>
/// Питомец
/// </summary>
public partial class Animal
{
    /// <summary>
    /// Ид питомца
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; } = null!;
    /// <summary>
    /// цена
    /// </summary>
    public long Amount { get; set; }
    /// <summary>
    /// Количество
    /// </summary>
    public int? Count { get; set; }
}
