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

        public async Task AddAsync(CartItem cartItem)
        {
            if (cartItem == null) return;

            await _context.CartItems.AddAsync(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            CartItem cartItem = await GetByIdAsync(id);

            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AdminDeleteCartItemAsync(int id)
        {
            var cartItem = await _context.CartItems.FindAsync(id);
            if (cartItem != null)
            {

                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }

        }

        public async Task<List<CartItem>> GetAllAsync()
        {
            return await _context.CartItems
             .Include(c => c.Equipment)
             .Include(c => c.Package)
             .Include(c => c.EquipmentSizes)
             .ToListAsync();
        }

        public async Task<CartItem?> GetByIdAsync(int id)
        {
            return await _context.CartItems
              .Include(c => c.Equipment)
              .Include(c => c.Package)
              .Include(c => c.EquipmentSizes)
              .FirstOrDefaultAsync(c => c.CartItemId == id);
        }

        public async Task UpdateAsync(CartItem cartItem)
        {
            _context.CartItems.Update(cartItem);
            await _context.SaveChangesAsync();
        }

        public async Task<CartItem> AdminUpdateCartItemAsync(CartItem cartItem)
        {

            CartItem? existing = await _context.CartItems.FindAsync(cartItem.CartItemId);

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

