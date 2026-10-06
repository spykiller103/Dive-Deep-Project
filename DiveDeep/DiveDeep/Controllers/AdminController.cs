using DiveDeep.DTOs;
using DiveDeep.Models;
using DiveDeep.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace DiveDeep.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ICartItemRepository _cartItemRepository;
        private IBookingRepository _bookingRepository;

        public AdminController(IHttpClientFactory httpClientFactory, ICartItemRepository cartItemRepository, IBookingRepository bookingRepository)
        {
            _cartItemRepository = cartItemRepository;
            _httpClientFactory = httpClientFactory;
            _bookingRepository = bookingRepository;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        public async Task<IActionResult> Update()
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                List<Equipment> equipment = await httpClient.GetFromJsonAsync<List<Equipment>>("WebApiAdmin/equipment");

                return View(equipment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipmentAsync(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", equipment);
            }

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.PostAsJsonAsync("WebApiAdmin/equipment", equipment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }


        public async Task<IActionResult> UpdateEquipment(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                Equipment equipment = await httpClient.GetFromJsonAsync<Equipment>($"WebApiAdmin/equipment/{id}");

                if (equipment == null)
                {
                    return NotFound();
                }

                return View(equipment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEquipmentAsync(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return View(equipment);
            }

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.PutAsJsonAsync($"WebApiAdmin/equipment/{equipment.EquipmentId}", equipment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteEquipmentAsync(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.DeleteAsync($"WebApiAdmin/equipment/{id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Update));
        }

        public async Task<IActionResult> EditBooking()
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                List<BookingDTO>? bookings = await httpClient.GetFromJsonAsync<List<BookingDTO>>("WebApiAdmin/booking");
                return View(bookings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPost]
        public async Task<IActionResult> DeleteBookingAsync(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.DeleteAsync($"WebApiAdmin/booking/{id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(EditBooking));
        }


        public async Task<IActionResult> EditBookingDetails(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                BookingDTO? booking = await httpClient.GetFromJsonAsync<BookingDTO>($"WebApiAdmin/booking/{id}");
                return View(booking);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCartItemAsync(int id, int bookingId)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.DeleteAsync($"WebApiAdmin/cartitem/{id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(EditBooking), new { id = bookingId });
        }

        public async Task<IActionResult> UpdateCartItem(int id, int bookingId)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                CartItemDTO cartItem = await httpClient.GetFromJsonAsync<CartItemDTO>($"WebApiAdmin/cartitem/{id}");

                ViewBag.BookingId = bookingId;

                return View("ChangeBookingDetails", cartItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBookingCartItem(CartItemDTO cartItem, int bookingId)
        {
            if (cartItem.EndDate >= cartItem.StartDate)
            {
                cartItem.TotalDays = (cartItem.EndDate - cartItem.StartDate).Days + 1;
            }

            if (!ModelState.IsValid)
            {
                ViewBag.BookingId = bookingId;
                return View("ChangeBookingDetails", cartItem);
            }

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.PutAsJsonAsync($"WebApiAdmin/cartitem/{cartItem.CartItemId}", cartItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(EditBookingDetails), new { id = bookingId });
        }

    }
}