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

        [NotMapped]
        public Dictionary<string, List<string>> EquipmentSizeRequirements { get; set; } = new Dictionary<string, List<string>>();

        public List<string> SizeList
        {
            get
            {
                if (string.IsNullOrWhiteSpace(Sizes))
                {
                    return new List<string> { "S", "M", "L", "XL" };
                }

                return Sizes.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).ToList();
            }
        }
        public List<CartItem> CartItems { get; set; }

        [NotMapped]
        public List<PackageEquipmentItem> EquipmentItems
        {
            get
            {
                var items = new List<PackageEquipmentItem>();
                if (Equipment != null)
                {
                    foreach (var equipmentName in Equipment)
                    {
                        var sizes = GetSizesForEquipment(equipmentName);
                        items.Add(new PackageEquipmentItem
                        {
                            Name = equipmentName,
                            AvailableSizes = sizes,
                            RequiresSize = sizes.Count > 0
                        });
                    }
                }
                return items;
            }
        }

        private List<string> GetSizesForEquipment(string equipmentName)
        {
            // Equipment categories that require sizes
            var sizedCategories = new[] { "BCD", "Dykkerdragt", "Finner" };
            
            // Check if this equipment name matches any of the sized categories
            foreach (var category in sizedCategories)
            {
                if (equipmentName.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return SizeList;
                }
            }
            
            return new List<string>();
        }
    }
}
