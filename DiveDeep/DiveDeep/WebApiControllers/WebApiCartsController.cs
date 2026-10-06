using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mapster;
using DiveDeep.DTOs;

namespace DiveDeep.WebApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiCartsController : ControllerBase
    {
        private readonly CartService _cartService;
        private readonly DiveDeepContext _context;
        private readonly IBookingRepository _bookingRepository;

        public WebApiCartsController(CartService cartService, IBookingRepository bookingRepository, DiveDeepContext context)
        {
            _cartService = cartService;
            _context = context;
            _bookingRepository = bookingRepository;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserCart(string userId)
        {
            List<CartItem> cartItems = (await _cartService.GetAllAsync())
                .Where(c => c.ApplicationUserId == userId && c.BookingId == null)
                .ToList();

            List<CartItemDTO> cartItemDTOs = cartItems.Adapt<List<CartItemDTO>>();

            return Ok(cartItemDTOs);
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveItemAsync(int id)
        {
            if (id <= 0)
                return BadRequest();

            var response = await _cartService.GetByIdAsync(id);

            if (response == null)
            {
                return NotFound();
            }

            await _cartService.DeleteAsync(id);

            return Ok();
        }


        [HttpPost("{userId}")]
        public async Task<IActionResult> Checkout(List<int> cartItemIds, string userId)
        {
            List<CartItem> cartItems = (await _cartService.GetAllAsync())
                .Where(c => cartItemIds
                .Contains(c.CartItemId) &&
                    c.ApplicationUserId == userId &&
                    c.BookingId == null)
                .ToList();


            Booking booking = await _bookingRepository.AddAsync(cartItems, userId);

            foreach (CartItem cartItem in cartItems)
            {
                cartItem.BookingId = booking.BookingId;
                await _cartService.UpdateAsync(cartItem);
            }
            return Ok();
        }
    }
}
