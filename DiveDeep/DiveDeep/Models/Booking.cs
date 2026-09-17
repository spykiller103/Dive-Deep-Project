using DiveDeep.Data;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeep.Models
{
    public class Booking
    {
        public int CartItemId { get; set; }
        public List<CartItem> CartItems { get; set; } = new();

        
        [Required]
        public string ApplicationUserId { get; set; }
        [ValidateNever]
        public ApplicationUser ApplicationUser { get; set; }
    }
}
