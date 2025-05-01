using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Subdivisions
{
    public int Id { get; set; }

    public string SubdivisionName { get; set; } = null!;

    public int? MilitaryUnitId { get; set; }

    public virtual MilitaryUnits? MilitaryUnit { get; set; }

    public virtual ICollection<ServiceHistory> ServiceHistory { get; set; } = new List<ServiceHistory>();

    public virtual ICollection<Servicemen> Servicemen { get; set; } = new List<Servicemen>();
}
