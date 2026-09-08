using Microsoft.AspNetCore.Mvc;
using DiveDeep.Persistence;
using DiveDeep.Models;

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

    }
}
