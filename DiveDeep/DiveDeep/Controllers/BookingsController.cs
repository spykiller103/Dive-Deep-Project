using AspNetCoreGeneratedDocument;
using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DiveDeep.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public BookingsController(IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, ICartItemRepository cartItemRepository)
        {
            _bookingRepository = bookingRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _cartItemRepository = cartItemRepository;
        }
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);
            
          

            BookingApplicationUserViewData vm = new BookingApplicationUserViewData
            {
                ApplicationUser = _userManager.Users.FirstOrDefault(u => u.Id == userId),

                Bookings = _bookingRepository.GetAll()
                    .Where(b => b.ApplicationUserId == userId)
                    .ToList(),
            
            };

           
            return View(vm);
        }
    }
}
