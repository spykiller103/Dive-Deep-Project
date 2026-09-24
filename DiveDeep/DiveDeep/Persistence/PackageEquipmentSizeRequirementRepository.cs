using DiveDeep.Data;
using DiveDeep.Models;
using Microsoft.EntityFrameworkCore;

namespace DiveDeep.Persistence
{
    public class PackageEquipmentSizeRequirementRepository : IPackageEquipmentSizeRequirementRepository
    {
        private readonly DiveDeepContext _context;

        public PackageEquipmentSizeRequirementRepository(DiveDeepContext context)
        {
            _context = context;
        }

        public List<PackageEquipmentSizeRequirement> GetAll()
        {
            return _context.PackageEquipmentSizeRequirements.ToList();
        }

        public List<PackageEquipmentSizeRequirement> GetByPackageId(int packageId)
        {
            return _context.PackageEquipmentSizeRequirements
                .Where(r => r.PackageId == packageId)
                .ToList();
        }

        public PackageEquipmentSizeRequirement? GetById(int id)
        {
            return _context.PackageEquipmentSizeRequirements
                .FirstOrDefault(r => r.Id == id);
        }

        public void Add(PackageEquipmentSizeRequirement requirement)
        {
            _context.PackageEquipmentSizeRequirements.Add(requirement);
            _context.SaveChanges();
        }

        public void Update(PackageEquipmentSizeRequirement requirement)
        {
            _context.PackageEquipmentSizeRequirements.Update(requirement);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var requirement = GetById(id);
            if (requirement != null)
            {
                _context.PackageEquipmentSizeRequirements.Remove(requirement);
                _context.SaveChanges();
            }
        }
    }
}