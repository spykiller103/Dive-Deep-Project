using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeep.Models
{
    public class CartItem
    {
        public int CartItemId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalDays { get; set; }
        public string? SelectedSize { get; set; }

        public int? PackageId { get; set; }
        public Package? Package { get; set; }

        public int? EquipmentId { get; set; }
        public Equipment? Equipment { get; set; }

        public int? BookingId { get; set; }
        public Booking? Booking { get; set; } = null!;

        [NotMapped]
        public Dictionary<string, string>? EquipmentSizes { get; set; }

        [NotMapped]
        public string? SerializedEquipmentSizes 
        { 
            get => EquipmentSizes != null ? string.Join(";", EquipmentSizes.Select(kv => $"{kv.Key}:{kv.Value}")) : null;
            set 
            {
                EquipmentSizes = new Dictionary<string, string>();
                if (!string.IsNullOrWhiteSpace(value))
                {
                    foreach (var pair in value.Split(';'))
                    {
                        var parts = pair.Split(':');
                        if (parts.Length == 2)
                        {
                            EquipmentSizes[parts[0]] = parts[1];
                        }
                    }
                }
            }
        }
    }
}
