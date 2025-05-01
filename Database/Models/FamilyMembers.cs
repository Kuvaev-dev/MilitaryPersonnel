using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class FamilyMembers
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public string? FullName { get; set; }

    public string? Relationship { get; set; }

    public DateOnly? BirthDate { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
