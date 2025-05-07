using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Serviceman
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50, ErrorMessage = "First name cannot exceed 50 characters.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50, ErrorMessage = "Last name cannot exceed 50 characters.")]
        public string LastName { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Middle name cannot exceed 50 characters.")]
        public string? MiddleName { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [DataType(DataType.Date)]
        public DateOnly BirthDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Civil profession ID must be a positive integer.")]
        public int? CivilProfessionId { get; set; }
        public string? CivilProfession { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Military specialty ID must be a positive integer.")]
        public int? MilitarySpecialtyId { get; set; }
        public string? MilitarySpecialty { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Education ID must be a positive integer.")]
        public int? EducationId { get; set; }
        public string? Education { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Position ID must be a positive integer.")]
        public int? PositionId { get; set; }
        public string? Position { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Subdivision ID must be a positive integer.")]
        public int? SubdivisionId { get; set; }
        public string? Subdivision { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Service form ID must be a positive integer.")]
        public int? ServiceFormId { get; set; }
        public string? ServiceForm { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Character trait ID must be a positive integer.")]
        public int? CharacterTraitId { get; set; }
        public string? CharacterTrait { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Service attitude ID must be a positive integer.")]
        public int? ServiceAttitudeId { get; set; }
        public string? ServiceAttitude { get; set; } = null!;

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string? Address { get; set; }

        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        [RegularExpression(@"^\+?[\d\s-]{7,20}$", ErrorMessage = "Invalid phone number format.")]
        public string? Phone { get; set; }

        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Service status ID must be a positive integer.")]
        public int? ServiceStatusId { get; set; }
        public string? ServiceStatus { get; set; } = null!;

        [Range(1, int.MaxValue, ErrorMessage = "Fitness category ID must be a positive integer.")]
        public int? FitnessCategoryId { get; set; }
        public string? FitnessCategory { get; set; }
        public bool? IsOfficer { get; set; }
    }
}
