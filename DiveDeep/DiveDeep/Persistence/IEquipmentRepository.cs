using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetAll();
        Equipment? GetById(int id);
        List<Equipment> GetByCategory(string category);
        Task<Equipment> CreateNewEquipment(Equipment equipment);
         Task<Equipment> UpdateEquipment(Equipment equipment);
        Task DeleteEquipment(int id);
     
        

    }
}
