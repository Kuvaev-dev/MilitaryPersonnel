using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Punishment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }

        [Required(ErrorMessage = "Punishment description is required.")]
        [StringLength(500, ErrorMessage = "Punishment description cannot exceed 500 characters.")]
        public string? PunishmentDescription { get; set; }

        [Required(ErrorMessage = "Punishment date is required.")]
        [DataType(DataType.Date)]
        public DateOnly? PunishmentDate { get; set; }
        public string? ServicemenFullName { get; set; }
    }
}
