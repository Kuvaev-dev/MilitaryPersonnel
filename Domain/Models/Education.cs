using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Education level is required.")]
        [StringLength(100, ErrorMessage = "Education level cannot exceed 100 characters.")]
        public string EducationLevel { get; set; } = null!;

        [StringLength(200, ErrorMessage = "Institution name cannot exceed 200 characters.")]
        public string? Institution { get; set; }

        [StringLength(200, ErrorMessage = "Specialty cannot exceed 200 characters.")]
        public string? Specialty { get; set; }

        [Range(1900, 2100, ErrorMessage = "Graduation year must be between 1900 and 2100.")]
        public int? GraduationYear { get; set; }
    }
}
