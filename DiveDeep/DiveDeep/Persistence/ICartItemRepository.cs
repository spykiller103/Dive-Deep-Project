using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public interface ICartItemRepository
    {
        void Add(CartItem cartItem);
        void Delete(int id);
        List<CartItem> GetAll();
        CartItem? GetById(int id);
        void Update(CartItem cartItem);
    }
}
