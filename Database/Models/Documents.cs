using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Documents
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public string? DocumentType { get; set; }

    public string? DocumentNumber { get; set; }

    public DateOnly? IssueDate { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
