using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public interface IBookingRepository
    {
        public Booking Add(List<CartItem> cartItems, string UserId);
        List<Booking> GetAll();
        Booking? GetById(int id);
        Task DeleteBookingAsync(int id);
        Task<List<Booking>> GetAllBookingsForAdminAsync();
        Task<Booking?> GetBookingByIdAsync(int id);
    }
}
