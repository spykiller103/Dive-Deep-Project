using DiveDeep.Data;
using DiveDeep.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiveDeep.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DiveDeepContext _context;

        public BookingRepository(DiveDeepContext context)
        {
            _context = context;
        }
        public Booking Add(List<CartItem> cartItems, string UserId)
        {
            Booking booking = new Booking
            {
                ApplicationUserId = UserId
            };

            _context.Bookings.Add(booking);
            _context.SaveChanges();

            foreach (CartItem cartItem in cartItems)
            {
                cartItem.BookingId = booking.BookingId;
                _context.CartItems.Update(cartItem);
            }

            _context.SaveChanges();

            return booking;
        }
        public List<Booking> GetAll()
        {
            return _context.Bookings
                .Include(b => b.CartItems)
                    .ThenInclude(c => c.EquipmentSizes)
                .Include(b => b.CartItems)
                    .ThenInclude(c => c.Package)
                .Include(b => b.CartItems)
                    .ThenInclude(c => c.Equipment)
                .ToList();
        }

        public Booking? GetById(int id)
        {
            return _context.Bookings
                .Include(b => b.CartItems)
                    .ThenInclude(ci => ci.Package)
                .Include(b => b.CartItems)
                    .ThenInclude(ci => ci.Equipment)
                .FirstOrDefault(b => b.BookingId == id);
        }
    }
}
