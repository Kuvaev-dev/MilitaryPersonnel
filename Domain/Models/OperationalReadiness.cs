using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class OperationalReadiness
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }
        public string? ServicemenFullName { get; set; }

        [Required(ErrorMessage = "Readiness status is required.")]
        [StringLength(100, ErrorMessage = "Readiness status cannot exceed 100 characters.")]
        public string? ReadinessStatus { get; set; }

        [Required(ErrorMessage = "Assessment date is required.")]
        [DataType(DataType.Date)]
        public DateOnly? AssessmentDate { get; set; }
    }
}
