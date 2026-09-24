namespace DiveDeep.Models
{
    public class CartItemEquipmentSize
    {
        public int Id { get; set; }
        public string EquipmentName { get; set; } = string.Empty;
        public string SelectedSize { get; set; } = string.Empty;

        public int CartItemId { get; set; }
        public CartItem? CartItem { get; set; }
    }
}