using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class RankAssignments
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public int? RankId { get; set; }

    public DateOnly AssignmentDate { get; set; }

    public virtual Ranks? Rank { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
