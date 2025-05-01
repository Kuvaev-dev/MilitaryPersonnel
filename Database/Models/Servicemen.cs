using System;
using System.Collections.Generic;

namespace Database.Models;

public partial class Servicemen
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? MiddleName { get; set; }

    public DateOnly BirthDate { get; set; }

    public int? CivilProfessionId { get; set; }

    public int? MilitarySpecialtyId { get; set; }

    public int? EducationId { get; set; }

    public int? PositionId { get; set; }

    public int? SubdivisionId { get; set; }

    public int? ServiceFormId { get; set; }

    public int? CharacterTraitId { get; set; }

    public int? ServiceAttitudeId { get; set; }

    public string? Address { get; set; }

    public string? Phone { get; set; }

    public string? Email { get; set; }

    public int? ServiceStatusId { get; set; }

    public int? FitnessCategoryId { get; set; }

    public bool? IsOfficer { get; set; }

    public virtual ICollection<Awards> Awards { get; set; } = new List<Awards>();

    public virtual CharacterTraits? CharacterTrait { get; set; }

    public virtual CivilProfessions? CivilProfession { get; set; }

    public virtual ICollection<ContactInfo> ContactInfo { get; set; } = new List<ContactInfo>();

    public virtual ICollection<Discharges> Discharges { get; set; } = new List<Discharges>();

    public virtual ICollection<DocumentAssignments> DocumentAssignments { get; set; } = new List<DocumentAssignments>();

    public virtual ICollection<DocumentFlow> DocumentFlow { get; set; } = new List<DocumentFlow>();

    public virtual ICollection<Documents> Documents { get; set; } = new List<Documents>();

    public virtual Educations? Education { get; set; }

    public virtual ICollection<FamilyMembers> FamilyMembers { get; set; } = new List<FamilyMembers>();

    public virtual FitnessCategories? FitnessCategory { get; set; }

    public virtual ICollection<LanguageSkills> LanguageSkills { get; set; } = new List<LanguageSkills>();

    public virtual ICollection<MedicalRecords> MedicalRecords { get; set; } = new List<MedicalRecords>();

    public virtual MilitarySpecialties? MilitarySpecialty { get; set; }

    public virtual ICollection<MobilizationListEntries> MobilizationListEntries { get; set; } = new List<MobilizationListEntries>();

    public virtual ICollection<OperationalReadiness> OperationalReadiness { get; set; } = new List<OperationalReadiness>();

    public virtual Positions? Position { get; set; }

    public virtual ICollection<PsychologicalProfiles> PsychologicalProfiles { get; set; } = new List<PsychologicalProfiles>();

    public virtual ICollection<Punishments> Punishments { get; set; } = new List<Punishments>();

    public virtual ICollection<RankAssignments> RankAssignments { get; set; } = new List<RankAssignments>();

    public virtual ICollection<Recruitments> Recruitments { get; set; } = new List<Recruitments>();

    public virtual ICollection<Resolutions> Resolutions { get; set; } = new List<Resolutions>();

    public virtual ServiceAttitudes? ServiceAttitude { get; set; }

    public virtual ServiceForms? ServiceForm { get; set; }

    public virtual ICollection<ServiceHistory> ServiceHistory { get; set; } = new List<ServiceHistory>();

    public virtual ServiceStatuses? ServiceStatus { get; set; }

    public virtual Subdivisions? Subdivision { get; set; }

    public virtual ICollection<Trainings> Trainings { get; set; } = new List<Trainings>();
}
