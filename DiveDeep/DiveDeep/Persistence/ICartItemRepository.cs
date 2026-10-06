using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public interface ICartItemRepository
    {
        Task AddAsync(CartItem cartItem);
        Task DeleteAsync(int id);
        Task<List<CartItem>> GetAllAsync();
        Task<CartItem>? GetByIdAsync(int id);
        Task UpdateAsync(CartItem cartItem);

        Task<CartItem> AdminUpdateCartItemAsync(CartItem cartItem);
    }
}
