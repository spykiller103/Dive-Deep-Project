using DiveDeep.Data;
using DiveDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DiveDeep.Persistence
{
    public class BookingEquipmentSizeRepository : IBookingEquipmentSizeRepository
    {
        private readonly DiveDeepContext _context;

        public BookingEquipmentSizeRepository(DiveDeepContext context)
        {
            _context = context;
        }

        public List<BookingEquipmentSize> GetAll()
        {
            return _context.BookingEquipmentSizes.ToList();
        }

        public List<BookingEquipmentSize> GetByBookingId(int bookingId)
        {
            return _context.BookingEquipmentSizes
                .Where(s => s.BookingId == bookingId)
                .ToList();
        }

        public BookingEquipmentSize? GetById(int id)
        {
            return _context.BookingEquipmentSizes
                .FirstOrDefault(s => s.Id == id);
        }

        public void Add(BookingEquipmentSize equipmentSize)
        {
            _context.BookingEquipmentSizes.Add(equipmentSize);
            _context.SaveChanges();
        }

        public void Update(BookingEquipmentSize equipmentSize)
        {
            _context.BookingEquipmentSizes.Update(equipmentSize);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var equipmentSize = GetById(id);
            if (equipmentSize != null)
            {
                _context.BookingEquipmentSizes.Remove(equipmentSize);
                _context.SaveChanges();
            }
        }
    }
}
