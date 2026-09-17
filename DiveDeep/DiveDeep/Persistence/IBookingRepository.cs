using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public interface IBookingRepository
    {
        List<Booking> GetAll();
        Booking? GetById(int id);
    }
}
