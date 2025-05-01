using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class LanguageSkill
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }
        public string? ServicemenFullName { get; set; }

        [Required(ErrorMessage = "Language is required.")]
        [StringLength(50, ErrorMessage = "Language cannot exceed 50 characters.")]
        public string? Language { get; set; }

        [Required(ErrorMessage = "Proficiency level is required.")]
        [StringLength(50, ErrorMessage = "Proficiency level cannot exceed 50 characters.")]
        public string? ProficiencyLevel { get; set; }
    }
}
