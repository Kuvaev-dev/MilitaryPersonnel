using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class vw_ServicemenDetails
{
    public int ServicemanId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public DateOnly BirthDate { get; set; }

    public string? CivilProfession { get; set; }

    public string? MilitarySpecialty { get; set; }

    public string? EducationLevel { get; set; }

    public string? RankName { get; set; }

    public string? PositionName { get; set; }

    public string? ServiceForm { get; set; }

    public string? SubdivisionName { get; set; }

    public string? MilitaryUnit { get; set; }
}
