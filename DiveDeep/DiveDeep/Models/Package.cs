using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeep.Models
{
    public class Package
    {
        [Range(0, 5)]
        public int Amount { get; set; } = 5;
        public int PackageId { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public List<string> Equipment { get; set; }
        public string? Sizes { get; set; }
        public List<CartItem> CartItems { get; set; }
        public List<PackageEquipmentSizeRequirement> EquipmentSizeRequirements { get; set; } = new List<PackageEquipmentSizeRequirement>();
    }
}
