using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class FitnessCategories
{
    public int Id { get; set; }

    public string CategoryName { get; set; } = null!;

    public virtual ICollection<Servicemen> Servicemen { get; set; } = new List<Servicemen>();
}
