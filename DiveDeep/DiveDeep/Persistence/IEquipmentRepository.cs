using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetAll();
        Equipment? GetById(int id);
    }
}
