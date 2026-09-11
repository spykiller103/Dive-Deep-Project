using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class ProfilesController : Controller
    {
        public IActionResult Index()
        {
            Profile profile = ProfileRepository.GetById(0);
            List<Booking>? bookings = BookingRepository.GetAll();

            ProfileBookingViewData vm = new ProfileBookingViewData
        {
                Profile = profile,
                Bookings = bookings
            };

            return View(vm);
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult SignUp()
        {
            return View();
        }
       
    }
}
