using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DiveDeep.Models
{
    public class Package
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public int Price { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public List<string> Equipment { get; set; }

        [Required]
        public DateTime? StartDate { get; set; }
        [Required]
        public DateTime? EndDate { get; set; }

        public int TotalDays { get; set; }
    }
}
