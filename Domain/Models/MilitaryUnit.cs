using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class MilitaryUnit
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Unit name is required.")]
        [StringLength(200, ErrorMessage = "Unit name cannot exceed 200 characters.")]
        public string UnitName { get; set; } = null!;

        public ICollection<Subdivision> Subdivisions { get; set; } = new List<Subdivision>();
    }
}
