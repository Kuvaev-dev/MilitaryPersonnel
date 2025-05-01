using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class LanguageSkills
{
    public int Id { get; set; }

    public int? ServicemanId { get; set; }

    public string? Language { get; set; }

    public string? ProficiencyLevel { get; set; }

    public virtual Servicemen? Serviceman { get; set; }
}
