using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class MilitaryUnits
{
    public int Id { get; set; }

    public string UnitName { get; set; } = null!;

    public virtual ICollection<Subdivisions> Subdivisions { get; set; } = new List<Subdivisions>();
}
