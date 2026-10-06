using DiveDeep.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeep.DTOs
{
    public class EquipmentDTO
    {
        [Range(0, 5)]
        public int Amount { get; set; } = 5;
        public int EquipmentId { get; set; }
        public string Category { get; set; }
        public string? Description { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public string? Sizes { get; set; }
    }
}
