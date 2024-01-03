using System;
using System.Collections.Generic;

namespace CProd;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public long Wallet { get; set; }
}
