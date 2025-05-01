using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class FitnessCategory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name cannot exceed 100 characters.")]
        public string CategoryName { get; set; } = null!;
    }
}
