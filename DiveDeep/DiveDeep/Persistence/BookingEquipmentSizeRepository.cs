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

        public async Task<List<BookingEquipmentSize>> GetAllAsync()
        {
            return await _context.BookingEquipmentSizes.ToListAsync();
        }

        public async Task<List<BookingEquipmentSize>> GetByBookingIdAsync(int bookingId)
        {
            return await _context.BookingEquipmentSizes
                .Where(s => s.BookingId == bookingId)
                .ToListAsync();
        }

        public async Task<BookingEquipmentSize?> GetByIdAsync(int id)
        {
            return await _context.BookingEquipmentSizes
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(BookingEquipmentSize equipmentSize)
        {
            await _context.BookingEquipmentSizes.AddAsync(equipmentSize);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(BookingEquipmentSize equipmentSize)
        {
            _context.BookingEquipmentSizes.Update(equipmentSize);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var equipmentSize = await GetByIdAsync(id);
            if (equipmentSize != null)
            {
                _context.BookingEquipmentSizes.Remove(equipmentSize);
                await _context.SaveChangesAsync();
            }
        }
    }
}
