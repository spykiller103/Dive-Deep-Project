namespace DiveDeep.Models
{
    public class Booking
    {

        public int CartItemId { get; set; }
        public List<CartItem> CartItems { get; set; } = new();
    }
}
