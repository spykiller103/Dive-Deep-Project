using DiveDeep.Data;
using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DiveDeepContext _context;

        public BookingRepository(DiveDeepContext context)
        {
            _context = context;
        }

        public List<Booking> GetAll()
        {
            return _context.Bookings.ToList();
        }

        public Booking? GetById(int id)
        {
            return null;
            /*
            return _bookingRepository.GetAll()
    .Where(b => b.ApplicationUserId == userId)
    .ToList();
            */
        }
    }
}
