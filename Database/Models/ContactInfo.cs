using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class ContactInfo
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public string? Address { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
