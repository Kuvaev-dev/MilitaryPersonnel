using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Discharges
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public DateOnly DischargeDate { get; set; }

    public string? DischargeReason { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
