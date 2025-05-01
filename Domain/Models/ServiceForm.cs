using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ServiceForm
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Form name is required.")]
        [StringLength(100, ErrorMessage = "Form name cannot exceed 100 characters.")]
        public string FormName { get; set; } = null!;
    }
}
