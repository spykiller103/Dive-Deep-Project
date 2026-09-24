using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using DiveDeep.Service;
using Microsoft.AspNetCore.Http;

namespace DiveDeep.Controllers
{
    public class EquipmentController : Controller
    {

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly CartService _cartService;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly PackageService _packageService;

        public EquipmentController(IEquipmentRepository equipmentRepository, CartService cartService, PackageService packageService)
        {
            _equipmentRepository = equipmentRepository;
            _cartService = cartService;
            _packageService = packageService;
        }
        public IActionResult Index(string? category)
        {
            List<Equipment> equipment;
            if (string.IsNullOrWhiteSpace(category))
            {
                equipment = _equipmentRepository.GetAll();
            }
            else
            {
                equipment = _equipmentRepository.GetByCategory(category);
            }

            return View(equipment);
        }

        public IActionResult Details(int id)
        {
            Equipment equipment = _equipmentRepository.GetById(id);

            return View(equipment);
        }


        [HttpPost]
        public IActionResult Reload(int buttonID)
        {
            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        [HttpPost]
        public IActionResult Rent(int id, string start, string end, string? size, IFormCollection form)
        {
            string userId = _userManager.GetUserId(User);
            Equipment equipmentToBeAdded = _equipmentRepository.GetById(id);

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

                Equipment equipment = _equipmentRepository.GetById(id);

                return View("Details", equipment);
            }

            int days = (endDate - startDate).Days + 1;

            if (days < 1)
            {
                days = 1;
            }

            CartItem cartItem = new CartItem
            {
                ApplicationUserId = userId,
                Equipment = equipmentToBeAdded,
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
