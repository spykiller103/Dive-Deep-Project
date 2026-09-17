using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiveDeep.Controllers
{
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public BookingsController(IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager)
        {
            _bookingRepository = bookingRepository;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User);

            BookingApplicationUserViewData vm = new BookingApplicationUserViewData
            {
                ApplicationUser = _userManager.Users.FirstOrDefault(u => u.Id == userId),

                Bookings = _bookingRepository.GetAll()
                    .Where(b => b.ApplicationUserId == userId)
                    .ToList()
            };
            return View(vm);
        }
    }
}
