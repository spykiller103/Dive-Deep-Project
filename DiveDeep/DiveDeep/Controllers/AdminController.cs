using DiveDeep.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace DiveDeep.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
                List<Equipment> equipment = await httpClient.GetFromJsonAsync<List<Equipment>>("WebApiAdmin");

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
                await httpClient.PostAsJsonAsync("WebApiAdmin", equipment);
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
                Equipment equipment = await httpClient.GetFromJsonAsync<Equipment>($"WebApiAdmin/{id}");

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
                await httpClient.PutAsJsonAsync($"WebApiAdmin/{equipment.EquipmentId}",equipment);
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
                await httpClient.DeleteAsync($"WebApiAdmin/{id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Update));
        }


        [HttpPost]
        public async Task<IActionResult> DeleteBookingAsync(int id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
            return RedirectToAction(nameof(EditBooking));
        }
        

        public async Task<IActionResult> EditBookingDetails(int id)
        {
            Booking? booking = await _bookingRepository.GetBookingByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCartItems(int id, int bookingId)
        {
            await _cartItemRepository.DeleteCartItemAsync(id);
            return RedirectToAction(nameof(EditBookingDetails), new { id = bookingId });
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCartItem(int id, int bookingId)
        {
            CartItem? cartItem = await _cartItemRepository.GetById(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            ViewBag.BookingId = bookingId;

            return View("ChangeBookingDetails", cartItem);
        }


        [HttpPost]
        public async Task<IActionResult> UpdateBookingCartItem(CartItem cartItem, int bookingId)
        {
            //if (!ModelState.IsValid)
            //{
            //    ViewBag.BookingId = bookingId;
            //    return View("ChangeBookingDetails", cartItem);
            //}

            await _cartItemRepository.UpdateCartItemAsync(cartItem);

            return RedirectToAction(nameof(EditBookingDetails), new { id = bookingId });


        }

    }
}