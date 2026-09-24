using System.ComponentModel.DataAnnotations.Schema;

namespace DiveDeep.Models
{
    public class PackageEquipmentSizeRequirement
    {
        public int Id { get; set; }
        public string EquipmentName { get; set; } = string.Empty;
        public string AvailableSizes { get; set; } = string.Empty;
        public bool RequiresSize { get; set; }

        public int PackageId { get; set; }
        public Package? Package { get; set; }
    }
}