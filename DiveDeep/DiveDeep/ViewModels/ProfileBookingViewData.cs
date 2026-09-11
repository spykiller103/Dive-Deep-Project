using DiveDeep.Models;

namespace DiveDeep.ViewModels
{
    public class ProfileBookingViewData
    {
        public Profile Profile { get; set; }

        public List<Booking>? Bookings { get; set; }
    }
}
