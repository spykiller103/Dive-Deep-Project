using Microsoft.AspNetCore.Mvc;
using DiveDeep.Persistence;
using DiveDeep.Models;
using DiveDeep.ViewModels;
using System;
using System.Globalization;

namespace DiveDeep.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            var equipment = EquipmentRepository.GetAll();
            return View(equipment);
        }


        [HttpPost]
        public IActionResult Reload(int buttonID)
        {
            var equipment = EquipmentRepository.GetAll();
            return View(equipment);
        }


        [HttpPost]
        public IActionResult Rent(int id, string start, string end)
        {

            Equipment equipmentToBeAdded = EquipmentRepository.GetById(id);

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

                List<Equipment> equipments = EquipmentRepository.GetAll();
                return View("Index", equipments);
            }

            int days = (endDate - startDate).Days + 1;

            if (days < 1)
            {
                days = 1;
            }

            CartItem cartItem = new CartItem
            {
                Equipment = equipmentToBeAdded,
                StartDate = startDate,
                EndDate = endDate,
                TotalDays = days
            };

            CartRepository.Add(cartItem);

            return RedirectToAction(nameof(Index));
        }
    }
}
