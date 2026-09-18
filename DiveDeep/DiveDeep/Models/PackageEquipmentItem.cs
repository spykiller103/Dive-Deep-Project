using System.Collections.Generic;

namespace DiveDeep.Models
{
    public class PackageEquipmentItem
    {
        public string Name { get; set; } = string.Empty;
        public List<string> AvailableSizes { get; set; } = new List<string>();
        public bool RequiresSize { get; set; }
    }
}