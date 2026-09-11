using System.ComponentModel.DataAnnotations;

namespace DiveDeep.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string ImageID { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }

        public int TotalDays { get; set; }
    }


}
