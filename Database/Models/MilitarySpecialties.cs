using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class MilitarySpecialties
{
    public int Id { get; set; }

    public string SpecialtyName { get; set; } = null!;

    public string? Code { get; set; }

    public virtual ICollection<Servicemen> Servicemen { get; set; } = new List<Servicemen>();
}
