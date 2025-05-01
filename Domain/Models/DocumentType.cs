using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Type name is required.")]
        [StringLength(100, ErrorMessage = "Type name cannot exceed 100 characters.")]
        public string TypeName { get; set; } = null!;
    }
}
