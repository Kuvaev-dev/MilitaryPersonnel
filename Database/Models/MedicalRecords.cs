using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class MedicalRecords
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public string? MedicalCondition { get; set; }

    public DateOnly? RecordDate { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
