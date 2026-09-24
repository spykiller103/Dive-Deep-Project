using DiveDeep.Data;
using DiveDeep.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DiveDeep.Persistence
{
    public class BookingRepository : IBookingRepository
    {
        private readonly DiveDeepContext _context;
        private readonly IBookingEquipmentSizeRepository _bookingEquipmentSizeRepository;

        public BookingRepository(DiveDeepContext context, IBookingEquipmentSizeRepository bookingEquipmentSizeRepository)
        {
            _context = context;
            _bookingEquipmentSizeRepository = bookingEquipmentSizeRepository;
        }
        public Booking Add(List<CartItem> cartItems, string UserId)
        {
            Booking booking = new Booking
            {
                CartItems = cartItems,
                ApplicationUserId = UserId
            };
            _context.Bookings.Add(booking);
            _context.SaveChanges();

            // Copy equipment sizes from cart items to booking equipment sizes
            foreach (var cartItem in cartItems)
            {
                if (cartItem.EquipmentSizes != null && cartItem.EquipmentSizes.Count > 0)
                {
                    foreach (var equipmentSize in cartItem.EquipmentSizes)
                    {
                        BookingEquipmentSize bookingEquipmentSize = new BookingEquipmentSize
                        {
                            EquipmentName = equipmentSize.EquipmentName,
                            SelectedSize = equipmentSize.SelectedSize,
                            BookingId = booking.BookingId
                        };
                        _bookingEquipmentSizeRepository.Add(bookingEquipmentSize);
                    }
                }
            }

            return booking;
        }
        public List<Booking> GetAll()
        {
            return _context.Bookings
                .Include(b => b.CartItems)
                    .ThenInclude(c => c.Package)
                .Include(b => b.CartItems)
                    .ThenInclude(c => c.Equipment)
                .Include(b => b.CartItems)
                    .ThenInclude(c => c.EquipmentSizes)
                .Include(b => b.EquipmentSizes)
                .ToList();
        }

        public Booking? GetById(int id)
        {
            return _context.Bookings
                .Include(b => b.CartItems)
                    .ThenInclude(ci => ci.Package)
                .Include(b => b.CartItems)
                    .ThenInclude(ci => ci.Equipment)
                .Include(b => b.EquipmentSizes)
                .FirstOrDefault(b => b.BookingId == id);
        }
    }
}
