using DiveDeep.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeep.Models
{
    public class Booking
    {
        public int BookingId { get; set; }
        public List<CartItem> CartItems { get; set; } = new();
        public List<BookingEquipmentSize> EquipmentSizes { get; set; } = new List<BookingEquipmentSize>();


        [Required]
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
