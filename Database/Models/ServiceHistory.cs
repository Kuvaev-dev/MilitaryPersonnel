using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class ServiceHistory
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public int? PositionId { get; set; }

    public int? SubdivisionId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Positions? Position { get; set; }

    public virtual Servicemen? Serviceman { get; set; }

    public virtual Subdivisions? Subdivision { get; set; }
}
