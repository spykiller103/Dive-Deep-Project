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
        public async Task<Booking> AddAsync(List<CartItem> cartItems, string UserId)
        {
            Booking booking = new Booking
            {
                ApplicationUserId = UserId
            };

            await _context.Bookings.AddAsync(booking);
            await _context.SaveChangesAsync();

            // Copy equipment sizes from cart items to booking equipment sizes
            foreach (var cartItem in cartItems)
            {
                if (cartItem.EquipmentSizes != null && cartItem.EquipmentSizes.Count > 0)
                {
                    foreach (CartItemEquipmentSize equipmentSize in cartItem.EquipmentSizes)
                    {
                        BookingEquipmentSize bookingEquipmentSize = new BookingEquipmentSize
                        {
                            EquipmentName = equipmentSize.EquipmentName,
                            SelectedSize = equipmentSize.SelectedSize,
                            BookingId = booking.BookingId
                        };
                        await _bookingEquipmentSizeRepository.AddAsync(bookingEquipmentSize);
                    }
                }
            }

            return booking;
        }
        public async Task<List<Booking>> GetAllAsync()
        {
            return await _context.Bookings
                .Include(b => b.CartItems)
                    .ThenInclude(c => c.EquipmentSizes)
                .Include(b => b.CartItems)
                    .ThenInclude(c => c.Package)
                .Include(b => b.CartItems)
                    .ThenInclude(c => c.Equipment)
                .Include(b => b.CartItems)
                    .ThenInclude(c => c.EquipmentSizes)
                .Include(b => b.EquipmentSizes)
                .ToListAsync();
        }

        public async Task<Booking?> GetByIdAsync(int id)
        {
            return await _context.Bookings
                .Include(b => b.CartItems)
                    .ThenInclude(ci => ci.Package)
                .Include(b => b.CartItems)
                    .ThenInclude(ci => ci.Equipment)
                .Include(b => b.EquipmentSizes)
                .FirstOrDefaultAsync(b => b.BookingId == id);
        }
    }
}
