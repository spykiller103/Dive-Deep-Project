namespace DiveDeep.Models
{
    public class BookingEquipmentSize
    {
        public int Id { get; set; }
        public string EquipmentName { get; set; } = string.Empty;
        public string SelectedSize { get; set; } = string.Empty;

        public int BookingId { get; set; }
        public Booking? Booking { get; set; }
    }
}
