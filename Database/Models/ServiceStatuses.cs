using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class ServiceStatuses
{
    public int Id { get; set; }

    public string StatusName { get; set; } = null!;

    public virtual ICollection<Servicemen> Servicemen { get; set; } = new List<Servicemen>();
}
