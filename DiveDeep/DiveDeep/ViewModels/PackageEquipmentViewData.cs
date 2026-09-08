using DiveDeep.Models;

namespace DiveDeep.ViewModels
{
    public class PackageEquipmentViewData
    {
        public List<Package> CartPackages { get; set; } = new();
        public List<Equipment> CartEquipments { get; set; } = new();
    }
}
