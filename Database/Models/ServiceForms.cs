using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class ServiceForms
{
    public int Id { get; set; }

    public string FormName { get; set; } = null!;

    public virtual ICollection<Servicemen> Servicemen { get; set; } = new List<Servicemen>();
}
