using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace DiveDeep.Controllers
{
    public class PackagesController : Controller
    {
        private readonly IPackageRepository _packageRepository;
        private readonly CartService _cartService;
        private readonly PackageService _packageService;

        public PackagesController(IPackageRepository packageRepository, CartService cartService, PackageService packageService)
        {
            _packageRepository = packageRepository;
            _cartService = cartService;
            _packageService = packageService;
        }

        public IActionResult Index()
        {
            List<Package> packages = _packageRepository.GetAll();
            return View(packages);
        }

        [HttpPost]
        public IActionResult Rent(int id, string start, string end, string? size, IFormCollection form)
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
                TotalDays = days
            };

            // Handle individual equipment sizes from the form
            List<CartItemEquipmentSize> equipmentSizes = new List<CartItemEquipmentSize>();
            foreach (string key in form.Keys)
            {
                if (key.StartsWith("equipmentSizes["))
                {
                    int startIndex = "equipmentSizes[".Length;
                    int endIndex = key.IndexOf("]");
                    string equipmentName = key.Substring(startIndex, endIndex - startIndex);
                    string selectedSize = form[key];
                    if (!string.IsNullOrWhiteSpace(selectedSize))
                    {
                        equipmentSizes.Add(new CartItemEquipmentSize
                        {
                            EquipmentName = equipmentName,
                            SelectedSize = selectedSize
                        });
                    }
                }
            }

            if (equipmentSizes.Count > 0)
            {
                cartItem.EquipmentSizes = equipmentSizes;
            }
            else if (!string.IsNullOrWhiteSpace(size))
            {
                // Fallback for backward compatibility
                cartItem.SelectedSize = size;
            }

            _cartService.Add(cartItem);

            return RedirectToAction(nameof(Index));
        }
    }
}
