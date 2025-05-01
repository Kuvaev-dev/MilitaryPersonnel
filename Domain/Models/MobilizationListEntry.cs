using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class MobilizationListEntry
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Mobilization list ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Mobilization list ID must be a positive integer.")]
        public int? MobilizationListId { get; set; }
        public string? MobilizationListName { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }
        public string? ServicemenFullName { get; set; }
    }
}
