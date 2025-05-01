using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Award
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }
        public string? ServicemenFullName { get; set; }

        [Required(ErrorMessage = "Award name is required.")]
        [StringLength(200, ErrorMessage = "Award name cannot exceed 200 characters.")]
        public string? AwardName { get; set; }

        [Required(ErrorMessage = "Award date is required.")]
        [DataType(DataType.Date)]
        public DateOnly? AwardDate { get; set; }
    }
}
