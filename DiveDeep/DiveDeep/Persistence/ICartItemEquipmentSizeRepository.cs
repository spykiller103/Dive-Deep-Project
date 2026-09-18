using DiveDeep.Models;

namespace DiveDeep.Persistence
{
    public interface ICartItemEquipmentSizeRepository
    {
        List<CartItemEquipmentSize> GetAll();
        List<CartItemEquipmentSize> GetByCartItemId(int cartItemId);
        CartItemEquipmentSize? GetById(int id);
        void Add(CartItemEquipmentSize equipmentSize);
        void Update(CartItemEquipmentSize equipmentSize);
        void Delete(int id);
    }
}