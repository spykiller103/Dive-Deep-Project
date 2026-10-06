using DiveDeep.Models;
using DiveDeep.Persistence;

namespace DiveDeep.Service
{
    public class CartService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICartItemEquipmentSizeRepository _equipmentSizeRepository;

        public CartService(ICartItemRepository cartItemRepository, ICartItemEquipmentSizeRepository equipmentSizeRepository)
        {
            _cartItemRepository = cartItemRepository;
            _equipmentSizeRepository = equipmentSizeRepository;
        }

        public async Task<CartItem?> GetByIdAsync(int id)
        {
            return await _cartItemRepository.GetByIdAsync(id);
        }

        public async Task<List<CartItem>> GetAllAsync()
        {
            return await _cartItemRepository.GetAllAsync();
        }



        public async Task AddAsync(CartItem cartItem)
        {
            await _cartItemRepository.AddAsync(cartItem);
            
            // Add equipment sizes if they exist
            if (cartItem.EquipmentSizes != null && cartItem.EquipmentSizes.Count > 0)
            {
                // Clear the equipment sizes from the cart item before adding to avoid circular reference
                List<CartItemEquipmentSize> equipmentSizes = cartItem.EquipmentSizes.ToList();
                cartItem.EquipmentSizes = new List<CartItemEquipmentSize>();
                
                foreach (var equipmentSize in equipmentSizes)
                {
                    equipmentSize.CartItemId = cartItem.CartItemId;
                    equipmentSize.Id = 0; // Let database auto-generate the ID
                    await _equipmentSizeRepository.AddAsync(equipmentSize);
                }
            }
        }

        public async Task UpdateAsync(CartItem cartItem)
        {
            await _cartItemRepository.UpdateAsync(cartItem);
            
            // Update equipment sizes
            List<CartItemEquipmentSize> existingSizes = await _equipmentSizeRepository.GetByCartItemIdAsync(cartItem.CartItemId);
            
            // Remove old sizes
            foreach (CartItemEquipmentSize? existingSize in existingSizes)
            {
                await _equipmentSizeRepository.DeleteAsync(existingSize.Id);
            }
            
            // Add new sizes
            if (cartItem.EquipmentSizes != null && cartItem.EquipmentSizes.Count > 0)
            {
                foreach (CartItemEquipmentSize? equipmentSize in cartItem.EquipmentSizes)
                {
                    equipmentSize.CartItemId = cartItem.CartItemId;
                    await _equipmentSizeRepository.AddAsync(equipmentSize);
                }
            }
        }

        public async Task DeleteAsync(int id)
        {
            // Delete associated equipment sizes first
            List<CartItemEquipmentSize> equipmentSizes = await _equipmentSizeRepository.GetByCartItemIdAsync(id);
            foreach (CartItemEquipmentSize? equipmentSize in equipmentSizes)
            {
                await _equipmentSizeRepository.DeleteAsync(equipmentSize.Id);
            }
            
            await _cartItemRepository.DeleteAsync(id);
        }
    }
}
