using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public interface ICartItemEquipmentSizeRepository
    {
        Task<List<CartItemEquipmentSize>> GetAllAsync();
        Task<List<CartItemEquipmentSize>> GetByCartItemIdAsync(int cartItemId);
        Task<CartItemEquipmentSize?> GetByIdAsync(int id);
        Task AddAsync(CartItemEquipmentSize equipmentSize);
        Task UpdateAsync(CartItemEquipmentSize equipmentSize);
        Task DeleteAsync(int id);
    }
}