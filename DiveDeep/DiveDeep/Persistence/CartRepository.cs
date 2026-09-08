using DiveDeep.Models;
namespace DiveDeep.Persistence
{
    public class CartRepository
    {
        public int Id { get; set; }
        public string ImageID { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
     
        public int Price { get; set; }
    }
}

