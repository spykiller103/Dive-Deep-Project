using DiveDeep.Data;
using DiveDeep.Models;

namespace DiveDeep.ViewModels
{
    public class BookingApplicationUserViewData
    {
        public List<Booking> Bookings { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public List<CartItem> CartItems { get; set; }
    }
}
