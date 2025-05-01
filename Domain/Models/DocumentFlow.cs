using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DocumentFlow
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(200, ErrorMessage = "Title cannot exceed 200 characters.")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(5000, ErrorMessage = "Content cannot exceed 5000 characters.")]
        public string Content { get; set; } = null!;

        [Required(ErrorMessage = "Document type ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Document type ID must be a positive integer.")]
        public int DocumentTypeId { get; set; }
        public string? DocumentType { get; set; }

        [Required(ErrorMessage = "Created by ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Created by ID must be a positive integer.")]
        public int CreatedById { get; set; }

        [Required(ErrorMessage = "Created date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        [Required(ErrorMessage = "Status ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Status ID must be a positive integer.")]
        public int StatusId { get; set; }
        public string? Status { get; set; }
        public string? CreatedBy { get; set; } = null!;
        public int? ServicemanId { get; set; }
        public string? ServicemanFullName { get; set; }
    }
}
