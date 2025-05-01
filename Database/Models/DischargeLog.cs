using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class DischargeLog
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public DateOnly? DischargeDate { get; set; }

    public string? DischargeReason { get; set; }

    public DateTime? LogDate { get; set; }
}
