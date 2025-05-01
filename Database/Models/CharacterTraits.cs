using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class CharacterTraits
{
    public int Id { get; set; }

    public string TraitName { get; set; } = null!;

    public virtual ICollection<Servicemen> Servicemen { get; set; } = new List<Servicemen>();
}
