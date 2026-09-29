using DiveDeep.Models;
using DiveDeep.Persistence;

namespace DiveDeep.Service
{
    public class AdminService : IAdminService
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public AdminService(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public async Task<Equipment> CreateNewEquipment(Equipment equipment)
        {
            return await _equipmentRepository.CreateNewEquipment(equipment);
            
        }

        public async Task DeleteEquipment(int id)
        {
            await _equipmentRepository.DeleteEquipment(id);
        }

        public async Task<Equipment> UpdateEquipment(Equipment equipment)
        {
            return await _equipmentRepository.UpdateEquipment(equipment);
        }
    }
}
