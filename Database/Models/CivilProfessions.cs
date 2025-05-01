using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class CivilProfessions
{
    public int Id { get; set; }

    public string ProfessionName { get; set; } = null!;

    public virtual ICollection<Servicemen> Servicemen { get; set; } = new List<Servicemen>();
}
