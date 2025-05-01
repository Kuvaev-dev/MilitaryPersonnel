using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class ContactInfo
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }
        public string? ServicemanFullName { get; set; }

        [StringLength(20, ErrorMessage = "Phone number cannot exceed 20 characters.")]
        [RegularExpression(@"^\+?[\d\s-]{7,20}$", ErrorMessage = "Invalid phone number format.")]
        public string? Phone { get; set; }

        [StringLength(100, ErrorMessage = "Email cannot exceed 100 characters.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string? Email { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters.")]
        public string? Address { get; set; }
    }
}
