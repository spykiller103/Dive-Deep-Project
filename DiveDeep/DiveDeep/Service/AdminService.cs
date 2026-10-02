using DiveDeep.Models;
using DiveDeep.Persistence;

namespace DiveDeep.Service
{
    public class AdminService 
    {
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly IBookingRepository _bookingRepository;

        public AdminService(IEquipmentRepository equipmentRepository, IBookingRepository bookingRepository)
        {
            _equipmentRepository = equipmentRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<Equipment> CreateEquipmentAsync(Equipment equipment)
        {
            return await _equipmentRepository.CreateEquipmentAsync(equipment);
            
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            await _equipmentRepository.DeleteEquipmentAsync(id);
        }

        public async Task<Equipment> UpdateEquipmentAsync(Equipment equipment)
        {
            return await _equipmentRepository.UpdateEquipmentAsync(equipment);
        }

        public async Task DeleteBookingAsync (int id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
        }
        public async Task<Booking?> GetBookingByIdAsync(int id)
        {
           return await _bookingRepository.GetBookingByIdAsync(id);
        }
    }
}
