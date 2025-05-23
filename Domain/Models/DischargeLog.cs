﻿using System.ComponentModel.DataAnnotations;

namespace Domain.Models
{
    public class DischargeLog
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Serviceman ID is required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Serviceman ID must be a positive integer.")]
        public int? ServicemanId { get; set; }
        public string? ServicemenFullName { get; set; }

        [Required(ErrorMessage = "Discharge date is required.")]
        [DataType(DataType.Date)]
        public DateOnly? DischargeDate { get; set; }

        [Required(ErrorMessage = "Discharge reason is required.")]
        [StringLength(500, ErrorMessage = "Discharge reason cannot exceed 500 characters.")]
        public string? DischargeReason { get; set; }

        [Required(ErrorMessage = "Log date is required.")]
        [DataType(DataType.DateTime)]
        public DateTime? LogDate { get; set; }
    }
}
