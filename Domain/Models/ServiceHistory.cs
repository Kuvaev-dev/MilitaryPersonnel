using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ServiceHistory
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }

        [Required(ErrorMessage = "Position ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Position ID must be a positive integer.")]
        public int? PositionId { get; set; }

        [Required(ErrorMessage = "Subdivision ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Subdivision ID must be a positive integer.")]
        public int? SubdivisionId { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? EndDate { get; set; }
        public string? PositionTitle { get; set; }
        public string? ServicemanFullName { get; set; }
        public string? SubdivisionTitle { get; set; }
    }
}
