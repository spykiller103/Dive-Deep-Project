using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeep.Models
{
    public class Equipment
    {
        public int EquipmentId { get; set; }
        public string Image { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int TotalDays { get; set; }

        public List<Profile>? Profiles { get; set; }
    }


}
