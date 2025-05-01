using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Positions
{
    public int Id { get; set; }

    public string PositionName { get; set; } = null!;

    public virtual ICollection<ServiceHistory> ServiceHistory { get; set; } = new List<ServiceHistory>();

    public virtual ICollection<Servicemen> Servicemen { get; set; } = new List<Servicemen>();
}
