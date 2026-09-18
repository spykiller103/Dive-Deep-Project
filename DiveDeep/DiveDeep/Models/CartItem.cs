using DiveDeep.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeep.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }
        public string? SelectedSize { get; set; }

        public int? PackageId { get; set; }
        public Package? Package { get; set; }

        public int? EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }

        public int? BookingId { get; set; }
        public Booking? Booking { get; set; } = null!;


        [Required]
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }

    }
}
