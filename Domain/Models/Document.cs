using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Document
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int ServicemanId { get; set; }

        [Display(Name = "Serviceman")]
        public string? ServicemenFullName { get; set; }

        [Required(ErrorMessage = "Document type is required.")]
        [StringLength(100, ErrorMessage = "Document type cannot exceed 100 characters.")]
        public string DocumentType { get; set; }

        [Required(ErrorMessage = "Document number is required.")]
        [StringLength(50, ErrorMessage = "Document number cannot exceed 50 characters.")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "Issue date is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? IssueDate { get; set; }
    }
}