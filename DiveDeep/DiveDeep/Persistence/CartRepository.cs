using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public static class CartRepository
    {
        private static List<CartItem> _cartItems = new List<CartItem>();

        public static List<CartItem> GetAll()
        {
            return _cartItems;
        }

        public static void Add(CartItem item)
        {
            _cartItems.Add(item);
        }

        public static void Delete(int index)
        {
            _cartItems.RemoveAt(index);
        }
    }
}

