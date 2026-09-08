using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public static class CartRepository
    {
        private static List<Equipment> _cartEquipments = new();
        private static List<Package> _cartPackages = new();

        public static void AddEquipment(Equipment equipment)
        {
            _cartEquipments.Add(equipment);
        }

        public static void AddPackage(Package package)
        {
            _cartPackages.Add(package);
        }

        public static List<Package> GetPackages()
        {
            return _cartPackages;
        }
        public static List<Equipment> GetEquipment()
        {
            return _cartEquipments;
        }
    }
}

