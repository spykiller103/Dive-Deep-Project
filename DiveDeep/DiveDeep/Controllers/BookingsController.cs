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
       // private string roleUser = "Bruger";
       // private string roleAdmin = "Admin";

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
            
           // ApplicationUser appUser = await _userManager.GetUserAsync(User);
           // bool doesRoleExist = await _roleManager.RoleExistsAsync(roleUser);

            BookingApplicationUserViewData vm = new BookingApplicationUserViewData
            {
                ApplicationUser = _userManager.Users.FirstOrDefault(u => u.Id == userId),

                Bookings = _bookingRepository.GetAll()
                    .Where(b => b.ApplicationUserId == userId)
                    .ToList(),
            
            };

            var bookingIds = vm.Bookings
                .Select(b => (int?)b.BookingId)
                .ToList(); //It is possible to use ToHashSet because its like a box that fast can check if the asked id is in there
            vm.CartItems = _cartItemRepository.GetAll()
                .Where(ci => bookingIds
                .Contains(ci.BookingId))
                .ToList();

            return View(vm);
        }
    }
}
