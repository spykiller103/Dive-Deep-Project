using Microsoft.AspNetCore.Mvc;
using DiveDeep.Persistence;
using DiveDeep.Models;
using DiveDeep.ViewModels;

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
        public IActionResult Rent(int id)
        {
            Equipment equipmentToBeAdded = EquipmentRepository.GetById(id);

            CartRepository.AddEquipment(equipmentToBeAdded);

            return RedirectToAction(nameof(Index));
        }
    }
}
