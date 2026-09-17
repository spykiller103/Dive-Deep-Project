using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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


       
    }
}
