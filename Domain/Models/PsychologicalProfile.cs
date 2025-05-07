using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class PsychologicalProfile
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }

        [Required(ErrorMessage = "Profile description is required.")]
        [StringLength(1000, ErrorMessage = "Profile description cannot exceed 1000 characters.")]
        public string? ProfileDescription { get; set; }

        [Required(ErrorMessage = "Assessment date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? AssessmentDate { get; set; }
        public string? ServicemenFullName { get; set; }
    }
}
