using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class Training
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Training name is required.")]
        [StringLength(200, ErrorMessage = "Training name cannot exceed 200 characters.")]
        public string? TrainingName { get; set; }

        [Required(ErrorMessage = "Start date is required.")]
        [DataType(DataType.Date)]
        public DateOnly? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateOnly? EndDate { get; set; }
        public string? ServicemenFullName { get; set; }
    }
}
