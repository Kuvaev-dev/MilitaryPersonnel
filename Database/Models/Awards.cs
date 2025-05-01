using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Awards
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public string? AwardName { get; set; }

    public DateOnly? AwardDate { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
