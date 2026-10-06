using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public interface IBookingRepository
    {
        Task<Booking> AddAsync(List<CartItem> cartItems, string UserId);
        Task<List<Booking>> GetAllAsync();
        Task<Booking?> GetByIdAsync(int id);
        Task DeleteBookingAsync(int id);
        Task<List<Booking>> GetAllBookingsForAdminAsync();
        Task<Booking?> GetBookingByIdAsync(int id);
    }
}
