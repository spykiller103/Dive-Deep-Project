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
    [Authorize]
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

        [HttpPost]
        public async Task<IActionResult> EmptyCart()
        {
            // Delete all cart items that are not part of a booking and only for the logged in user
            
            List<CartItem> cartItems = (await _cartService.GetAllAsync())
                .Where(c => c.BookingId == null)
                .ToList();

            ApplicationUser user = await _userManager.GetUserAsync(User);
            
            if (user != null)
            {
                var userCartItems = await _context.CartItems
                         .Where(c => c.ApplicationUserId == user.Id)
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
