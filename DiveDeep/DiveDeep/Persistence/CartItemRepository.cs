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

        public void Delete(int id)
        {
            CartItem cartItem = _context.CartItems.Find(id);
            if (cartItem == null) return;

            _context.CartItems.Remove(cartItem);
            _context.SaveChanges();
        }

        public void AssignProfileToAllCartItems(int profileId)
        {
            var items = _context.CartItems
                .Where(c => c.ProfileId == null || c.ProfileId == 0)
                .ToList();

            if (!items.Any()) return;

            foreach (var item in items)
            {
                item.ProfileId = profileId;
            }

            _context.SaveChanges();
        }

        public List<CartItem> GetAll()
        {
            return _context.CartItems
             .Where(c => c.ProfileId == null)
             .Include(c => c.Equipment)
             .Include(c => c.Package)
             .ToList();
        }

        public CartItem? GetById(int id)
        {
            return _context.CartItems
              .Include(c => c.Equipment)
              .Include(c => c.Package)
              .FirstOrDefault(c => c.CartItemId == id);
        }

        public void Update(CartItem cartItem)
        {
            if (cartItem == null) return;

            CartItem existing = _context.CartItems.Find(cartItem.CartItemId);
            if (existing == null) return;

            existing.CartItemId = cartItem.CartItemId;
            existing.StartDate = cartItem.StartDate;
            existing.EndDate = cartItem.EndDate;
            existing.TotalDays = cartItem.TotalDays;

            _context.SaveChanges();
        }
    }
}
