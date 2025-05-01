using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class OperationalReadiness
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public string? ReadinessStatus { get; set; }

    public DateOnly? AssessmentDate { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
