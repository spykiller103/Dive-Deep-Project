using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeep.Models
{
    public class Equipment
    {
        [Range(0, 5)]
        public int Amount { get; set; } = 5;
        public int EquipmentId { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }

        public List<CartItem> CartItems { get; set; }

        [NotMapped]
        public string? Sizes { get; set; }

        [NotMapped]
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
    }
}
