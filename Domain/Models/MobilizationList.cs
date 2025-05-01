using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class MobilizationList
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "List name is required.")]
        [StringLength(200, ErrorMessage = "List name cannot exceed 200 characters.")]
        public string ListName { get; set; } = null!;

        [Required(ErrorMessage = "Creation date is required.")]
        [DataType(DataType.Date)]
        public DateOnly? CreationDate { get; set; }
    }
}
