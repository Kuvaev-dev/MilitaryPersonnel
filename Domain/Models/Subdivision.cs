using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Subdivision
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Subdivision name is required.")]
        [StringLength(200, ErrorMessage = "Subdivision name cannot exceed 200 characters.")]
        public string SubdivisionName { get; set; } = null!;

        [Required(ErrorMessage = "Military unit ID is required.")]
        public int MilitaryUnitId { get; set; }
        public string? MilitaryUnit { get; set; } = null!;
    }
}
