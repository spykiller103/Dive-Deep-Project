using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DiveDeep.Controllers
{
    public class PackagesController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPackageRepository _packageRepository;
        private readonly CartService _cartService;

        public PackagesController(IPackageRepository packageRepository, CartService cartService, UserManager<ApplicationUser> userManager)
        {
            _packageRepository = packageRepository;
            _cartService = cartService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Package> packages = _packageRepository.GetAll();
            return View(packages);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Rent(int id, string start, string end, string? size)
        {
            string userId = _userManager.GetUserId(User);
            Package packagesToBeAdded = _packageRepository.GetById(id);

            DateTime startDate, endDate;
            bool _start = DateTime.TryParseExact(start,
                new[] { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);

            bool _end = DateTime.TryParseExact(end,
                new[] { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            if (!_start || !_end)
            {
                int key = id;
                ModelState.AddModelError(key.ToString(), "Vælg venligst både start- og slutdato.");

                List<Package> packages = _packageRepository.GetAll();

                return View("Index", packages);
            }

            int days = (endDate - startDate).Days + 1;

            if (days < 1)
            {
                days = 1;
            }

            CartItem cartItem = new CartItem
            {
                Package = packagesToBeAdded,
                StartDate = startDate,
                EndDate = endDate,
                TotalDays = days,
                ApplicationUserId = userId
            };

            if (!string.IsNullOrWhiteSpace(size))
            {
                cartItem.SelectedSize = size;
            }

            _cartService.Add(cartItem);

            return RedirectToAction(nameof(Index));
        }
    }
}
