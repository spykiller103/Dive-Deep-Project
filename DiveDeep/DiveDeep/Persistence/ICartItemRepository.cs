using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public interface ICartItemRepository
    {
        void Add(CartItem cartItem);
        Task Delete(int id);
        List<CartItem> GetAll();
        Task<CartItem?> GetById(int id);
        void Update(CartItem cartItem);

        Task DeleteCartItemAsync(int id);
        Task<CartItem> UpdateCartItemAsync(CartItem cartItem);
    }
}
