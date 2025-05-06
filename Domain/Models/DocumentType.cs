using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DocumentType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string TypeName { get; set; }
    }
}