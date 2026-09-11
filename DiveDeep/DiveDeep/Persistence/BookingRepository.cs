using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public static class BookingRepository
    {
        private static List<Booking> _bookings = new List<Booking>();

        public static List<Booking> GetAll()
        {
            return _bookings;
        }

        public static void Add(Booking booking)
        {
            booking.BookingId = _bookings.Count + 1;
            _bookings.Add(booking);
        }
    }
}
