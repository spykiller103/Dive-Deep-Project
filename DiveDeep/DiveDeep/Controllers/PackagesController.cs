using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DiveDeep.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackageRepository _packageRepository;
        private readonly CartService _cartService;

        public PackagesController(IPackageRepository packageRepository, CartService cartService)
        {
            _packageRepository = packageRepository;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            List<Package> packages = _packageRepository.GetAll();
            return View(packages);
        }

        public IActionResult Details(int id)
        {
            Package package = _packageRepository.GetById(id);

            return View(package);
        }


        [HttpPost]
        public IActionResult Rent(int id, string start, string end, string? size)
        {
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

                ModelState.AddModelError(
                    key.ToString(),
                    "Vælg venligst både start- og slutdato."
                );

                Package package = _packageRepository.GetById(id);

                return View("Details", package);
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
                TotalDays = days
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
