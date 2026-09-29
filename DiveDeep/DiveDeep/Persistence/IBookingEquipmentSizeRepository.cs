using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public interface IBookingEquipmentSizeRepository
    {
        List<BookingEquipmentSize> GetAll();
        List<BookingEquipmentSize> GetByBookingId(int bookingId);
        BookingEquipmentSize? GetById(int id);
        void Add(BookingEquipmentSize equipmentSize);
        void Update(BookingEquipmentSize equipmentSize);
        void Delete(int id);
    }
}
