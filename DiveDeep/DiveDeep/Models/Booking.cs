using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeep.Models
{
    public class Booking
    {
        public int BookingId { get; set; }

        public int ProfileId { get; set; }
        public Profile Profile { get; set; }

        public List<CartItem> Items { get; set; } = new();
    }
}
