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

        public List<Equipment> GetAll()
        {
            return _context.Equipments
                .ToList();
        }

        public Equipment? GetById(int id)
        {
            return _context.Equipments
                .FirstOrDefault(e => e.EquipmentId == id);
        }

        public List<Equipment> GetByCategory(string category)
        {
            if (string.IsNullOrWhiteSpace(category))
            {
                return GetAll();
            }

            string equipmentCategory = category;
            return _context.Equipments
                .Where(e => !string.IsNullOrEmpty(e.Category) && e.Category == equipmentCategory)
                .ToList();
        }

       
    }
}
