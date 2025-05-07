using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Resolution
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Document ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Document ID must be a positive integer.")]
        public int DocumentId { get; set; }

        [Required(ErrorMessage = "Author ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Author ID must be a positive integer.")]
        public int AuthorId { get; set; }

        [Required(ErrorMessage = "Resolution text is required.")]
        [StringLength(1000, ErrorMessage = "Resolution text cannot exceed 1000 characters.")]
        public string ResolutionText { get; set; } = null!;

        [Required(ErrorMessage = "Resolution date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime? ResolutionDate { get; set; }
        public string? AuthorFullName { get; set; } = null!;
        public string? DocumentTitle { get; set; } = null!;
    }
}
