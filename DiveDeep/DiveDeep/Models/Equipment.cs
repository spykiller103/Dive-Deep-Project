using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeep.Models
{
    public class Equipment
    {
        [Range(0, 5)]
        public int Amount { get; set; } = 5;
        public int EquipmentId { get; set; }
        [ValidateNever]
        public string Image { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        [ValidateNever]
        public List<CartItem> CartItems { get; set; }

        public string? Sizes { get; set; }
    }
}
