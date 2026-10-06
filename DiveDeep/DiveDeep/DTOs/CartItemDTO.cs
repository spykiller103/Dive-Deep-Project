using DiveDeep.Data;
using DiveDeep.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeep.DTOs
{
    public class CartItemDTO
    {
        public int CartItemId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }
        public string? SelectedSize { get; set; }

        public int? PackageId { get; set; }
        public PackageDTO? Package { get; set; }

        public int? EquipmentId { get; set; }
        public EquipmentDTO? Equipment { get; set; }

        public int? BookingId { get; set; }

        public List<CartItemEquipmentSize> EquipmentSizes { get; set; } = new List<CartItemEquipmentSize>();


        [Required]
        public string ApplicationUserId { get; set; }
    }
}
