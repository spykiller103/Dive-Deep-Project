using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DiveDeep.WebApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiCartsController : ControllerBase
    {
        private readonly CartService _cartService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly DiveDeepContext _context;
        private readonly IBookingRepository _bookingRepository;

        public WebApiCartsController(CartService cartService, IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager, DiveDeepContext context)
        {
            _cartService = cartService;
            _userManager = userManager;
            _context = context;
            _bookingRepository = bookingRepository;
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserCart(string userId)
        {
            List<CartItem> cartItems = (await _cartService.GetAllAsync())
                .Where(c => c.ApplicationUserId == userId && c.BookingId == null)
                .ToList();

            return Ok(cartItems);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> EmptyCart(string userId)
        {
            if (userId != null)
            {
                List<CartItem> userCartItems = await _context.CartItems
                         .Where(c => c.ApplicationUserId == userId)
                         .ToListAsync();

                _context.CartItems.RemoveRange(userCartItems);

                await _context.SaveChangesAsync();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
