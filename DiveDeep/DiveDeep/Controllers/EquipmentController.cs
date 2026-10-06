using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using Microsoft.AspNetCore.Http;

namespace DiveDeep.Controllers
{
    public class EquipmentController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly CartService _cartService;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly PackageService _packageService;
        private readonly IHttpClientFactory _httpClientFactory;

        public EquipmentController(
            IEquipmentRepository equipmentRepository,
            CartService cartService,
            PackageService packageService,
            UserManager<ApplicationUser> userManager,
            IHttpClientFactory httpClientFactory)
        {
            _equipmentRepository = equipmentRepository;
            _cartService = cartService;
            _packageService = packageService;
            _userManager = userManager;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                List<Equipment> response = await httpClient.GetFromJsonAsync<List<Equipment>>("WebApiEquipment");

                return View(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                Equipment response = await httpClient.GetFromJsonAsync<Equipment>($"WebApiEquipment/{id}");

                return View(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Rent(int id, string start, string end, 
            string? size, IFormCollection form)
        {
            string userId = _userManager.GetUserId(User);

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                var test = await httpClient.PostAsync($"WebApiEquipment?id={id}&start={start}&end={end}&size={size}&userId={userId}", null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}