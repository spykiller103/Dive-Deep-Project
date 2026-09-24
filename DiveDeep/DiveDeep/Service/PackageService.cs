using DiveDeep.Models;
using DiveDeep.Persistence;

namespace DiveDeep.Service
{
    public class PackageService
    {
        private readonly IPackageEquipmentSizeRequirementRepository _sizeRequirementRepository;

        public PackageService(IPackageEquipmentSizeRequirementRepository sizeRequirementRepository)
        {
            _sizeRequirementRepository = sizeRequirementRepository;
        }

        public List<string> GetSizeList(string? sizes)
        {
            if (string.IsNullOrWhiteSpace(sizes))
            {
                return new List<string> { "S", "M", "L", "XL" };
            }

            return sizes.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).ToList();
        }

        public List<PackageEquipmentSizeRequirement> GetEquipmentItems(Package package)
        {
            List<PackageEquipmentSizeRequirement> items = new List<PackageEquipmentSizeRequirement>();
            
            // Get size requirements from database for this package
            List<PackageEquipmentSizeRequirement> dbRequirements = _sizeRequirementRepository.GetByPackageId(package.PackageId);
            
            if (package.Equipment != null)
            {
                foreach (string equipmentName in package.Equipment)
                {
                    // Check if we have a database entry for this equipment
                    PackageEquipmentSizeRequirement? dbRequirement = dbRequirements.FirstOrDefault(r => 
                        r.EquipmentName.Equals(equipmentName, StringComparison.OrdinalIgnoreCase));
                    
                    if (dbRequirement != null)
                    {
                        // Use database data
                        items.Add(dbRequirement);
                    }
                    else
                    {
                        // Fall back to automatic detection if no database entry
                        var sizeList = GetSizeList(package.Sizes);
                        var sizes = GetSizesForEquipment(equipmentName, sizeList);
                        items.Add(new PackageEquipmentSizeRequirement
                        {
                            EquipmentName = equipmentName,
                            AvailableSizes = string.Join(",", sizes),
                            RequiresSize = sizes.Count > 0,
                            PackageId = package.PackageId
                        });
                    }
                }
            }
            return items;
        }

        private List<string> GetSizesForEquipment(string equipmentName, List<string> availableSizes)
        {
            string[] sizedCategories = new[] { "BCD", "Dykkerdragt", "Finner" };
            
            foreach (string category in sizedCategories)
            {
                if (equipmentName.IndexOf(category, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    return availableSizes;
                }
            }
            
            return new List<string>();
        }

        //public List<string> GetEquipmentSizeList(string category, string? sizes)
        //{
        //    var sizedCategories = new[] { "BCD", "Dykkerdragt", "Finner" };

        //    if (string.IsNullOrWhiteSpace(category) || !sizedCategories.Any(c => string.Equals(c, category, StringComparison.OrdinalIgnoreCase)))
        //    {
        //        return new List<string>();
        //    }

        //    if (string.IsNullOrWhiteSpace(sizes))
        //    {
        //        return new List<string> { "S", "M", "L", "XL" };
        //    }

        //    return sizes.Split(',').Select(s => s.Trim()).Where(s => s.Length > 0).ToList();
        //}

        //public List<PackageEquipmentSizeRequirement> GetEquipmentSizeRequirements(int packageId)
        //{
        //    return _sizeRequirementRepository.GetByPackageId(packageId);
        //}
    }
}