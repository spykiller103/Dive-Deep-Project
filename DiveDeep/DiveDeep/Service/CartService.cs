using DiveDeep.Models;
using DiveDeep.Persistence;
using System.Security.AccessControl;

namespace DiveDeep.Service
{
    public class CartService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
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
        }

        public void Update(CartItem cartItem)
        {
            _cartItemRepository.Update(cartItem);

        }

        public void Delete(int id)
        {
            _cartItemRepository.Delete(id);
        }

        public void AssignProfileToAllCartItems(int profileId)
        {
            _cartItemRepository.AssignProfileToAllCartItems(profileId);
        }
    }
}

           
