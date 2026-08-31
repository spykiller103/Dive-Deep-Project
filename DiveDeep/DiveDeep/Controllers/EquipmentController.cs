using Microsoft.AspNetCore.Mvc;
using DiveDeep.Persistence;

namespace DiveDeep.Controllers
{
    public class EquipmentController : Controller
    {
        public IActionResult Index()
        {
            var equipment = EquipmentRepository.GetAll();
            return View(equipment);
        }
    }
}
