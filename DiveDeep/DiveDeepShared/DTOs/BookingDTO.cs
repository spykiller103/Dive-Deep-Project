using DiveDeepShared.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeepShared.DTOs
{
    public class BookingDTO
    {
        public int BookingId { get; set; }
        public List<CartItemDTO> CartItems { get; set; } = new();
        public List<BookingEquipmentSize> EquipmentSizes { get; set; } = new();

        public string ApplicationUserId { get; set; }
        public ApplicationUserDTO? ApplicationUser { get; set; }
    }
}
