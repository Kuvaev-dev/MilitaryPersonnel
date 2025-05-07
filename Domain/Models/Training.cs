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
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? StartDate { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
        public DateOnly? EndDate { get; set; }

        [Required(ErrorMessage = "Serviceman Id is required.")]
        public int ServicemanId { get; set; }

        public string? ServicemenFullName { get; set; }
    }
}
