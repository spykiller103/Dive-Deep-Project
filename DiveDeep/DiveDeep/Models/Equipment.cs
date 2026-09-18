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

        public List<string> SizeList
        {
            get
            {
                // Only certain categories should have sizes (BCD, diving suits, and fins).
                // For categories that don't need sizes (e.g. masks, tanks), return an empty list so the UI
                // won't render size selection controls.
                var sizedCategories = new[] { "BCD", "Dykkerdragt", "Finner" };

                if (string.IsNullOrWhiteSpace(Category) || !sizedCategories.Any(c => string.Equals(c, Category, StringComparison.OrdinalIgnoreCase)))
                {
                    // Ignore any Sizes value for categories that don't require sizes.
                    return new List<string>();
                }

                if (string.IsNullOrWhiteSpace(Sizes))
                {
                    return new List<string> { "S", "M", "L", "XL" };
                }

                return Sizes.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).ToList();
            }
        }
    }
}
