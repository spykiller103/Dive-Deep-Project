using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace DiveDeep.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class WebApiBookingsController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly ICartItemRepository _cartItemRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        public WebApiBookingsController(IBookingRepository bookingRepository, ICartItemRepository cartItemRepository, UserManager<ApplicationUser> userManager)
        {
            _bookingRepository = bookingRepository;
            _cartItemRepository = cartItemRepository;
            _userManager = userManager;
        }


        [HttpGet("{userId}")]
        public async Task<IActionResult> Index(string userId)
        {
            if (userId == null)
            {
                return NotFound();
            }

            List<Booking> bookings = (await _bookingRepository.GetAllAsync())
                            .Where(b => b.ApplicationUserId == userId)
                            .ToList();

            DateTime today = DateTime.Today;

            var activeBookings = bookings
                .Where(b => b.CartItems.Any(c =>
                    c.StartDate.Date <= today &&
                    c.EndDate.Date >= today))
                .ToList();

            var upcomingBookings = bookings
                .Where(b => b.CartItems.Any(c =>
                    c.StartDate.Date > today))
                .ToList();

            var completedBookings = bookings
                .Where(b => b.CartItems.Any() &&
                            b.CartItems.All(c =>
                                c.EndDate.Date < today))
                .ToList();


            BookingApplicationUserViewData vm = new BookingApplicationUserViewData
            {
                ApplicationUser = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == userId),

                Bookings = bookings,

                ActiveBookingCount = activeBookings.Count,
                UpcomingBookingCount = upcomingBookings.Count,
                CompletedBookingCount = completedBookings.Count,
                TotalRentalPeriods = bookings.Count,

                ActiveBookings = activeBookings,
                UpcomingBookings = upcomingBookings,
                CompletedBookings = completedBookings
            };

            return Ok(vm);
        }
    }
}
