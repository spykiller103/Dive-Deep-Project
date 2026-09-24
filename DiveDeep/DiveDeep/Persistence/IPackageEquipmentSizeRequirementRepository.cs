using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public interface IPackageEquipmentSizeRequirementRepository
    {
        List<PackageEquipmentSizeRequirement> GetAll();
        List<PackageEquipmentSizeRequirement> GetByPackageId(int packageId);
        PackageEquipmentSizeRequirement? GetById(int id);
        void Add(PackageEquipmentSizeRequirement requirement);
        void Update(PackageEquipmentSizeRequirement requirement);
        void Delete(int id);
    }
}