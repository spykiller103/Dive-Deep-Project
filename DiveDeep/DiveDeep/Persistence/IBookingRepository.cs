using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public interface IBookingRepository
    {
        public void Add(List<CartItem> cartItems, string UserId);
        List<Booking> GetAll();
        Booking? GetById(int id);
    }
}
