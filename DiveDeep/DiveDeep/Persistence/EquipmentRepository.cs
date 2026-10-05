using DiveDeep.Models;
using DiveDeep.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DiveDeep.Persistence
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private readonly DiveDeepContext _context;

        public EquipmentRepository(DiveDeepContext context)
        {
            _context = context;
        }

        public async Task<List<Equipment>> GetAll()
        {
            return await _context.Equipments
                .ToListAsync();
        }

        public async Task<Equipment?> GetById(int id)
        {
            return await _context.Equipments
                .FirstOrDefaultAsync(e => e.EquipmentId == id);
        }

        public List<Equipment> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return _context.Equipments
                    .ToList();
            }

            string equipmentCategory = category;

            return _context.Equipments
                .Where(e => !string.IsNullOrEmpty(e.Category) &&
                            e.Category == equipmentCategory)
                .ToList();
        }

        public async Task<Equipment> CreateEquipment(Equipment equipment)
        {
            _context.Equipments.Add(equipment);
            await _context.SaveChangesAsync();

            return equipment;
        }

        public async Task<Equipment> UpdateEquipment(Equipment equipment)
        {
            var existing = await _context.Equipments
                .FindAsync(equipment.EquipmentId);

            if (existing != null)
            {
                existing.Title = equipment.Title;
                existing.Description = equipment.Description;
                existing.Category = equipment.Category;
                existing.Price = equipment.Price;
                existing.Amount = equipment.Amount;

                await _context.SaveChangesAsync();
            }

            return existing ?? equipment;
        }

        public async Task DeleteEquipment(int id)
        {
            var equipment = await _context.Equipments
                .FindAsync(id);

            if (equipment != null)
            {
                var cartItems = await _context.CartItems
                    .Where(c => c.EquipmentId == id)
                    .ToListAsync();

                _context.CartItems.RemoveRange(cartItems);

                _context.Equipments.Remove(equipment);

                await _context.SaveChangesAsync();
            }
        }
    }
}