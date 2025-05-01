using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class MilitarySpecialty
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Specialty name is required.")]
        [StringLength(100, ErrorMessage = "Specialty name cannot exceed 100 characters.")]
        public string SpecialtyName { get; set; } = null!;

        [StringLength(50, ErrorMessage = "Code cannot exceed 50 characters.")]
        public string? Code { get; set; }
    }
}
