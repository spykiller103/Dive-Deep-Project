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

        public CartItem? GetById(int id)
        {
            return _cartItemRepository.GetById(id);
        }

        public List<CartItem> GetAll()
        {
            return _cartItemRepository.GetAll();
        }

        public void Add(CartItem cartItem)
        {
            _cartItemRepository.Add(cartItem);
            
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
                    _equipmentSizeRepository.Add(equipmentSize);
                }
            }
        }

        public void Update(CartItem cartItem)
        {
            _cartItemRepository.Update(cartItem);
            
            // Update equipment sizes
            List<CartItemEquipmentSize> existingSizes = _equipmentSizeRepository.GetByCartItemId(cartItem.CartItemId);
            
            // Remove old sizes
            foreach (CartItemEquipmentSize? existingSize in existingSizes)
            {
                _equipmentSizeRepository.Delete(existingSize.Id);
            }
            
            // Add new sizes
            if (cartItem.EquipmentSizes != null && cartItem.EquipmentSizes.Count > 0)
            {
                foreach (CartItemEquipmentSize? equipmentSize in cartItem.EquipmentSizes)
                {
                    equipmentSize.CartItemId = cartItem.CartItemId;
                    _equipmentSizeRepository.Add(equipmentSize);
                }
            }
        }

        public void Delete(int id)
        {
            // Delete associated equipment sizes first
            List<CartItemEquipmentSize> equipmentSizes = _equipmentSizeRepository.GetByCartItemId(id);
            foreach (CartItemEquipmentSize? equipmentSize in equipmentSizes)
            {
                _equipmentSizeRepository.Delete(equipmentSize.Id);
            }
            
            _cartItemRepository.Delete(id);
        }
    }
}
