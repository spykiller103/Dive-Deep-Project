using DiveDeep.Data;
using DiveDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DiveDeep.Persistence
{
    public class CartItemEquipmentSizeRepository : ICartItemEquipmentSizeRepository
    {
        private readonly DiveDeepContext _context;

        public CartItemEquipmentSizeRepository(DiveDeepContext context)
        {
            _context = context;
        }

        public async Task<List<CartItemEquipmentSize>> GetAllAsync()
        {
            return await _context.CartItemEquipmentSizes.ToListAsync();
        }

        public async Task<List<CartItemEquipmentSize>> GetByCartItemIdAsync(int cartItemId)
        {
            return await _context.CartItemEquipmentSizes
                .Where(s => s.CartItemId == cartItemId)
                .ToListAsync();
        }

        public async Task<CartItemEquipmentSize?> GetByIdAsync(int id)
        {
            return await _context.CartItemEquipmentSizes
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task AddAsync(CartItemEquipmentSize equipmentSize)
        {
            await _context.CartItemEquipmentSizes.AddAsync(equipmentSize);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CartItemEquipmentSize equipmentSize)
        {
            _context.CartItemEquipmentSizes.Update(equipmentSize);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var equipmentSize = await GetByIdAsync(id);
            if (equipmentSize != null)
            {
                _context.CartItemEquipmentSizes.Remove(equipmentSize);
                await _context.SaveChangesAsync();
            }
        }
    }
}