using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ServiceStatus
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Status name is required.")]
        [StringLength(100, ErrorMessage = "Status name cannot exceed 100 characters.")]
        public string StatusName { get; set; } = null!;
    }
}
