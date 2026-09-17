using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
namespace DiveDeep.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private readonly CartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IBookingRepository _bookingRepository;

        public CartsController(CartService cartService, IEquipmentRepository equipmentRepository, IPackageRepository packageRepository, IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
            _bookingRepository = bookingRepository;
        }

        public IActionResult Index()
        {
            List<CartItem> cartItems = _cartService.GetAll();

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult Checkout(List<int> cartItemIds)
        {
            string user = _userManager.GetUserId(User);

            List<CartItem> cartItems = new();

            foreach (int id in cartItemIds)
                cartItems.Add(_cartService.GetById(id));

            _bookingRepository.Add(cartItems, user);

            return RedirectToAction(nameof(Index));
        }
    }
}
