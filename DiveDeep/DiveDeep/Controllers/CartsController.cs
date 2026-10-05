using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiveDeep.Controllers
{
    [Authorize]
    public class CartsController : Controller
    {
        private readonly CartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DiveDeepContext _context;
        private readonly IBookingRepository _bookingRepository;

        private readonly IHttpClientFactory _httpClientFactory;

        public CartsController(CartService cartService, IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager, DiveDeepContext context, IHttpClientFactory httpClientFactory)
        {
            _cartService = cartService;
            _userManager = userManager;
            _context = context;
            _bookingRepository = bookingRepository;
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<IActionResult> EmptyCart()
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                httpClient.PostAsync("WebApiCarts", null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        public IActionResult Index()
        {
            string userId = _userManager.GetUserId(User);

            List<CartItem> cartItems = _cartService.GetAll()
                .Where(c => c.ApplicationUserId == userId && c.BookingId == null)
                .ToList();

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult Checkout(List<int> cartItemIds)
        {
            string userId = _userManager.GetUserId(User);

            List<CartItem> cartItems = _cartService.GetAll()
                .Where(c => cartItemIds
                .Contains(c.CartItemId) &&
                    c.ApplicationUserId == userId &&
                    c.BookingId == null)
                .ToList();


            Booking booking = _bookingRepository.Add(cartItems, userId);

            foreach (CartItem cartItem in cartItems)
            {
                cartItem.BookingId = booking.BookingId;
                _cartService.Update(cartItem);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveItem(int id)
        {
            _cartService.Delete(id);
            return View();
        }
    }
}