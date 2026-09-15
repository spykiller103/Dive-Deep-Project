using DiveDeep.Models;

namespace DiveDeep.ViewModels
{
    public class ProfileCartItemViewData
    {
        public Profile Profile { get; set; }

        public List<CartItem>? CartItems { get; set; }
    }
}
