using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class MedicalRecord
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }
        public string? ServicemenFullName { get; set; }

        [Required(ErrorMessage = "Medical condition is required.")]
        [StringLength(500, ErrorMessage = "Medical condition cannot exceed 500 characters.")]
        public string? MedicalCondition { get; set; }

        [Required(ErrorMessage = "Record date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? RecordDate { get; set; }
    }
}
