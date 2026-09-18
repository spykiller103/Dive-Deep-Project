using DiveDeep.Data;
using DiveDeep.Models;

namespace DiveDeep.ViewModels
{
    public class BookingApplicationUserViewData
    {
        public List<Booking> Bookings { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int ActiveBookingCount { get; set; }
        public int UpcomingBookingCount { get; set; }
        public int CompletedBookingCount { get; set; }
        public int TotalRentalPeriods { get; set; }

        public List<Booking> ActiveBookings { get; set; } = new List<Booking>();
        public List<Booking> UpcomingBookings { get; set; } = new List<Booking>();
        public List<Booking> CompletedBookings { get; set; } = new List<Booking>();
    }
}
