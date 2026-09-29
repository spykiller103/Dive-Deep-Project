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
        public  IActionResult Create()
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
                return View("Create",equipment);
            }
            await _equipmentRepository.CreateEquipment(equipment);
            return RedirectToAction(nameof(Create));
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
            Console.WriteLine("POST UpdateEquipment blev kaldt!");

            foreach (var error in ModelState)
            {
                foreach (var message in error.Value.Errors)
                {
                    Console.WriteLine($"FEJL i {error.Key}: {message.ErrorMessage}");
                }
            }

            if (!ModelState.IsValid)
            {
                Console.WriteLine("ModelState er IKKE valid!");
                return View(equipment);
            }

            Console.WriteLine("ModelState er valid!");

            await _equipmentRepository.UpdateEquipment(equipment);

            Console.WriteLine("UpdateEquipment repository er færdig!");

            return RedirectToAction(nameof(Index));
        }

    }
}
