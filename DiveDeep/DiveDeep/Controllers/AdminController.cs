using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {


        private readonly IEquipmentRepository _equipmentRepository;

        public AdminController(IEquipmentRepository equipmentRepository)
        {

            _equipmentRepository = equipmentRepository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Update()
        {
            var equipment = _equipmentRepository.GetAll();
            return View(equipment);
        }
      
        [HttpPost]
        public async Task<IActionResult> CreateEquipment(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {

                return View("Create", equipment);
            }

            await _equipmentRepository.CreateEquipment(equipment);

            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult UpdateEquipment(int id)
        {
            var equipment = _equipmentRepository.GetById(id);
            if (equipment == null)
            {
                return NotFound();
            }
            return View(equipment);
        }
        //Saves the updated changes
        [HttpPost]
        public async Task<IActionResult> UpdateEquipment(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return View(equipment);
            }
            await _equipmentRepository.UpdateEquipment(equipment);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            await _equipmentRepository.DeleteEquipment(id);

            return RedirectToAction(nameof(Update));
        }

    }
}
