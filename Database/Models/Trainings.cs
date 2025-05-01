using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Trainings
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public string? TrainingName { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
