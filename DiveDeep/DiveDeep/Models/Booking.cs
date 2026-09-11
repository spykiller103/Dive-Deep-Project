using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeep.Models
{
    public class Booking
    {
        public List<Package> Packages { get; set; }
        public List<Equipment> Equipments { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }

    }
}
