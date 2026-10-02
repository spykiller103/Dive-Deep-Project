using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace DiveDeep.Controllers
{
    public class PackagesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPackageRepository _packageRepository;
        private readonly CartService _cartService;
        private readonly PackageService _packageService;
        private readonly IHttpClientFactory _httpClientFactory;

        public PackagesController
            (IPackageRepository packageRepository, CartService cartService, PackageService packageService, UserManager<ApplicationUser> userManager, IHttpClientFactory httpClientFactory)
        {
            _packageRepository = packageRepository;
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
                List<Package> response = await httpClient.GetFromJsonAsync<List<Package>>("WebApiPackages");

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
                Package response = await httpClient.GetFromJsonAsync<Package>($"WebApiPackages/{id}");
                return View(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Rent(int id, string start, string end, string? size, IFormCollection form)
        {
            string userId = _userManager.GetUserId(User);

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                var test = await httpClient.PostAsync($"WebApiPackages?id={id}&start={start}&end={end}&size={size}&userId={userId}", null);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}
