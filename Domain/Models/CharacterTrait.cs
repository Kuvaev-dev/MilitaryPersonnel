using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class CharacterTrait
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Trait name is required.")]
        [StringLength(100, ErrorMessage = "Trait name cannot exceed 100 characters.")]
        public string TraitName { get; set; } = null!;
    }
}
