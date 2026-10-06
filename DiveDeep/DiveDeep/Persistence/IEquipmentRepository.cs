using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public interface IEquipmentRepository
    {
        Task<List<Equipment>> GetAllAsync();
        Task<Equipment?> GetByIdAsync(int id);
        Task<List<Equipment>> GetByCategoryAsync(string category);

        Task<Equipment> CreateEquipmentAsync(Equipment equipment);
        Task<Equipment> UpdateEquipmentAsync(Equipment equipment);
        Task DeleteEquipmentAsync(int id);
    }
}