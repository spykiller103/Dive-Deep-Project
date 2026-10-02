using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public interface IEquipmentRepository
    {
        List<Equipment> GetAll();
        Equipment? GetById(int id);
        List<Equipment> GetByCategory(string category);
        Task<Equipment> CreateEquipmentAsync(Equipment equipment);
         Task<Equipment> UpdateEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(int id);
     
        

    }
}
