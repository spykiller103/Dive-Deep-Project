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

        public static Booking? GetById(int id)
        {
            return _bookings.FirstOrDefault(x => x.BookingId == id);
        }

        public static void Add(Booking booking)
        {
            booking.BookingId = _bookings.Count + 1;
            _bookings.Add(booking);
        }

        public static void Delete(int bookingId)
        {
            _bookings.RemoveAll(x => x.BookingId == bookingId);
        }
    }
}
