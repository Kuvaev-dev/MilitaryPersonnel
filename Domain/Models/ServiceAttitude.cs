using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ServiceAttitude
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Attitude description is required.")]
        [StringLength(500, ErrorMessage = "Attitude description cannot exceed 500 characters.")]
        public string AttitudeDescription { get; set; } = null!;
    }
}
