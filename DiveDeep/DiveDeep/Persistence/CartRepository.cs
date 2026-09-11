using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public static class CartRepository
    {
        private static List<Booking> _cartBookings = new();

        public static void AddBooking(Booking booking)
        {
            _cartBookings.Add(booking);
        }

        public static List<Booking> GetBookings()
        {
            return _cartBookings;
        }
    }
}

