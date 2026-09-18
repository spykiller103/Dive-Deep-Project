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

        public CartsController(CartService cartService, IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager)
        {
            _cartService = cartService;
            _userManager = userManager;
            _bookingRepository = bookingRepository;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EmptyCart()
        {
            // Delete all cart items that are not part of a booking
            List<CartItem> cartItems = _cartService.GetAll()
                .Where(c => c.BookingId == null)
                .ToList();

            foreach (var item in cartItems)
            {
                _cartService.Delete(item.CartItemId);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            List<CartItem> cartItems = _cartService.GetAll()
                .Where(c => c.BookingId == null)
                .ToList();

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult Checkout(List<int> cartItemIds)
        {
            List<CartItem> cartItems = new();

            string user = _userManager.GetUserId(User);

            foreach (int id in cartItemIds)
            {
                cartItems.Add(_cartService.GetById(id));
            }

            Booking booking = _bookingRepository.Add(cartItems, user);

            foreach (CartItem cartItem in cartItems)
            {
                cartItem.BookingId = booking.BookingId;
                _cartService.Update(cartItem);
            }

            return RedirectToAction("Index");
        }
    }
}