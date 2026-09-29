using DiveDeep.Models;

namespace DiveDeep.Service
{
    public interface IAdminService
    {
        Task<Equipment> CreateNewEquipment(Equipment equipment);
        Task<Equipment> UpdateEquipment(Equipment equipment);
        Task DeleteEquipment(int id);
    }
}
