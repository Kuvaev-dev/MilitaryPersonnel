using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Ranks
{
    public int Id { get; set; }

    public string RankName { get; set; } = null!;

    public virtual ICollection<RankAssignments> RankAssignments { get; set; } = new List<RankAssignments>();
}
