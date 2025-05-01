using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class ServiceAttitudes
{
    public int Id { get; set; }

    public string AttitudeDescription { get; set; } = null!;

    public virtual ICollection<Servicemen> Servicemen { get; set; } = new List<Servicemen>();
}
