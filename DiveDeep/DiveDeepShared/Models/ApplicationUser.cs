using Microsoft.AspNetCore.Identity;

namespace DiveDeepShared.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }

        public List<Booking> Bookings { get; set; } = new();
        public List<CartItem> CartItems { get; set; } = new();
    }
}
