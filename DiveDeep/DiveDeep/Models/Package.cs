namespace DiveDeep.Models
{
    public class Package
    {
        public int Id { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public List<string> Equipment { get; set; }
    }
}
