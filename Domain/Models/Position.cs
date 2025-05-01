using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Position name is required.")]
        [StringLength(100, ErrorMessage = "Position name cannot exceed 100 characters.")]
        public string PositionName { get; set; } = null!;
    }
}
