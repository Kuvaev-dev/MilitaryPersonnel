using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Recruitments
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public DateOnly RecruitmentDate { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
