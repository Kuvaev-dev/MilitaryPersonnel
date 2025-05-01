using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class CivilProfession
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Profession name is required.")]
        [StringLength(100, ErrorMessage = "Profession name cannot exceed 100 characters.")]
        public string ProfessionName { get; set; } = null!;
    }
}
