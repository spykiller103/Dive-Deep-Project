using Azure;
using DiveDeep.Data;
using DiveDeep.DTOs;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Mapster;
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
        private readonly IBookingRepository _bookingRepository;

        private readonly IHttpClientFactory _httpClientFactory;

        public CartsController(CartService cartService, IBookingRepository bookingRepository, UserManager<ApplicationUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _cartService = cartService;
            _userManager = userManager;
            _bookingRepository = bookingRepository;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(User);

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                List<CartItem> response = await httpClient.GetFromJsonAsync<List<CartItem>>($"WebApiCarts/{userId}");

                return View(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
        public async Task<IActionResult> EmptyCart()
        {
            string userId = _userManager.GetUserId(User);

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.DeleteAsync($"WebApiCarts/empty/{userId}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(List<int> cartItemIds)
        {
            string userId = _userManager.GetUserId(User);

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.PostAsJsonAsync($"WebApiCarts/{userId}", cartItemIds);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> RemoveItemAsync(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.DeleteAsync($"WebApiCarts/{id}");
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}