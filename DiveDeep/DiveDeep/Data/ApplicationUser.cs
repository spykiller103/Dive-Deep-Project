using DiveDeep.Models;
using Microsoft.AspNetCore.Identity;
namespace DiveDeep.Data;
// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName 
    {
        get
        {
            return $"{FirstName} {LastName}";
        } 
    }

    public int? ActiveRents { get; set; }
    public int? CompletedRents { get; set; }
    public int? Rents
    {
        get
        {
            return ActiveRents + CompletedRents;
        }
    }

    public List<Booking>? Bookings { get; set; } = new();
}
