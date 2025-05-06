using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DocumentFlow
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(255, ErrorMessage = "Title cannot exceed 255 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required.")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Document type is required.")]
        public int DocumentTypeId { get; set; }

        [Display(Name = "Document Type")]
        public string? DocumentType { get; set; }

        [Required(ErrorMessage = "Created by is required.")]
        public int CreatedById { get; set; }

        [Display(Name = "Created By")]
        public string? CreatedBy { get; set; }

        [Required(ErrorMessage = "Serviceman is required.")]
        public int ServicemanId { get; set; }

        [Display(Name = "Serviceman")]
        public string? ServicemanFullName { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        [Required(ErrorMessage = "Status is required.")]
        public int StatusId { get; set; }

        [Display(Name = "Status")]
        public string? Status { get; set; }
    }
}