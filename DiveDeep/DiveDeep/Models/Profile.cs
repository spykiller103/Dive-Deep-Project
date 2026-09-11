using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace DiveDeep.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string Email { get; set; }
        public int ActiveRents { get; set; }
        public int CompletedRents { get; set; }
        public int Rents
        {
            get
            {
                return ActiveRents + CompletedRents;
            }
        }

        public List<Booking> Bookings { get; set; } = new();
    }
}
