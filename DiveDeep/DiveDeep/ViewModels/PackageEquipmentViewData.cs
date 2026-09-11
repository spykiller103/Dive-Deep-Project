using DiveDeep.Models;

namespace DiveDeep.ViewModels
{
    public class PackageEquipmentViewData
    {
        public List<Package> Packages { get; set; }
        public List<Package> CartPackages { get; set; }
        public List<Equipment> CartEquipments { get; set; }
    }
}
