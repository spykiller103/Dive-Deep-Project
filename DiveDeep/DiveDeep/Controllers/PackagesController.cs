using DiveDeep.Models;
using DiveDeep.Persistence;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DiveDeep.Controllers
{
    public class PackagesController : Controller
    {
        public IActionResult Index()
        {
            List<Package> packeges = PackageRepository.GetAll();
            return View(packeges);
        }

        [HttpPost]
        public IActionResult Rent(int id, string start, string end)
        {
            Package packagesToBeAdded = PackageRepository.GetById(id);

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

                List<Package> package = PackageRepository.GetAll();

                return View("Index", package);
            }

            int days = (endDate - startDate).Days + 1;

            if (days < 1)
            {
                days = 1;
            }

            packagesToBeAdded.TotalDays = days;

            CartItem cartItem = new CartItem
            {
                Package = packagesToBeAdded,
                StartDate = startDate,
                EndDate = endDate,
                TotalDays = days
            };

            CartRepository.Add(cartItem);

            return RedirectToAction(nameof(Index));
        }
    }
}
