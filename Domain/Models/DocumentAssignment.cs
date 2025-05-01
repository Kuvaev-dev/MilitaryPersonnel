using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DocumentAssignment
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Document ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Document ID must be a positive integer.")]
        public int DocumentId { get; set; }
        public string? DocumentTitle { get; set; }

        [Required(ErrorMessage = "Assignee ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Assignee ID must be a positive integer.")]
        public int AssigneeId { get; set; }

        [Required(ErrorMessage = "Assigned date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime? AssignedDate { get; set; }

        [Required(ErrorMessage = "Completion status is required.")]
        public bool? IsCompleted { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? CompletedDate { get; set; }
        public string? ServicemenFullName { get; set; }
    }
}
