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

        public List<CartItemEquipmentSize> GetAll()
        {
            return _context.CartItemEquipmentSizes.ToList();
        }

        public List<CartItemEquipmentSize> GetByCartItemId(int cartItemId)
        {
            return _context.CartItemEquipmentSizes
                .Where(s => s.CartItemId == cartItemId)
                .ToList();
        }

        public CartItemEquipmentSize? GetById(int id)
        {
            return _context.CartItemEquipmentSizes
                .FirstOrDefault(s => s.Id == id);
        }

        public void Add(CartItemEquipmentSize equipmentSize)
        {
            _context.CartItemEquipmentSizes.Add(equipmentSize);
            _context.SaveChanges();
        }

        public void Update(CartItemEquipmentSize equipmentSize)
        {
            _context.CartItemEquipmentSizes.Update(equipmentSize);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var equipmentSize = GetById(id);
            if (equipmentSize != null)
            {
                _context.CartItemEquipmentSizes.Remove(equipmentSize);
                _context.SaveChanges();
            }
        }
    }
}