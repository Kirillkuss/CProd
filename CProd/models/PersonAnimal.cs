using System;
using System.Collections.Generic;

namespace CProd;

public partial class PersonAnimal
{
    public int? Idperson { get; set; }

    public int? Idanimal { get; set; }

    public virtual Animal? IdanimalNavigation { get; set; }

    public virtual Person? IdpersonNavigation { get; set; }
}
