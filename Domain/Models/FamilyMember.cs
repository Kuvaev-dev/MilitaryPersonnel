using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class FamilyMember
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }

        [Required(ErrorMessage = "Full name is required.")]
        [StringLength(100, ErrorMessage = "Full name cannot exceed 100 characters.")]
        public string? FullName { get; set; }

        [Required(ErrorMessage = "Relationship is required.")]
        [StringLength(50, ErrorMessage = "Relationship cannot exceed 50 characters.")]
        public string? Relationship { get; set; }

        [Required(ErrorMessage = "Birth date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? BirthDate { get; set; }
        public string? ServicemenFullName { get; set; }
    }
}
