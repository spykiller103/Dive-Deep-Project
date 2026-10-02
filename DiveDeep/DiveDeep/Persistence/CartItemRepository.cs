using DiveDeep.Data;
using DiveDeep.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DiveDeep.Persistence
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly DiveDeepContext _context;

        public CartItemRepository(DiveDeepContext context)
        {
            _context = context;
        }

        public void Add(CartItem cartItem)
        {
            if (cartItem == null) return;

            _context.CartItems.Add(cartItem);
            _context.SaveChanges();
        }

        public async Task Delete(int id)
        {
            CartItem? cartItem = await GetById(id);

            if(cartItem != null)
            {
            _context.CartItems.Remove(cartItem);
            await _context.SaveChangesAsync();

            }
        }

        public async Task DeleteCartItemAsync(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {
              
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

        }

        public List<CartItem> GetAll()
        {
            return _context.CartItems
             .Include(c => c.Equipment)
             .Include(c => c.Package)
             .Include(c => c.EquipmentSizes)
             .ToList();
        }

        public async Task<CartItem?> GetById(int id)
        {
            return await _context.CartItems
              .Include(c => c.Equipment)
              .Include(c => c.Package)
              .Include(c => c.EquipmentSizes)
              .FirstOrDefaultAsync(c => c.CartItemId == id);
        }

        public void Update(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            _context.SaveChanges();
        }

        public async Task<CartItem> UpdateCartItemAsync(CartItem cartItem)
        {

            var existing = await _context.CartItems
                .FindAsync(cartItem.CartItemId);
            if (existing != null)
            {
                existing.StartDate = cartItem.StartDate;
                existing.EndDate = cartItem.EndDate;
                existing.SelectedSize = cartItem.SelectedSize;

                await _context.SaveChangesAsync();
            }
            return existing ?? cartItem;
        }
    
    }
}
