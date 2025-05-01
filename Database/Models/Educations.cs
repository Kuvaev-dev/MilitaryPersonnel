using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Educations
{
    public int Id { get; set; }

    public string EducationLevel { get; set; } = null!;

    public string? Institution { get; set; }

    public string? Specialty { get; set; }

    public int? GraduationYear { get; set; }

    public virtual ICollection<Servicemen> Servicemen { get; set; } = new List<Servicemen>();
}
