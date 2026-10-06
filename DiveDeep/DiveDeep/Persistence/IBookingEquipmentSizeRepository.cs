using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public interface IBookingEquipmentSizeRepository
    {
        Task<List<BookingEquipmentSize>> GetAllAsync();
        Task<List<BookingEquipmentSize>> GetByBookingIdAsync(int bookingId);
        Task<BookingEquipmentSize?> GetByIdAsync(int id);
        Task AddAsync(BookingEquipmentSize equipmentSize);
        Task UpdateAsync(BookingEquipmentSize equipmentSize);
        Task DeleteAsync(int id);
    }
}
