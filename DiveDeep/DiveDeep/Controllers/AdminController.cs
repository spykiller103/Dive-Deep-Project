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

        public AdminController( IEquipmentRepository equipmentRepository)
        {
           
            _equipmentRepository = equipmentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        
        public async Task<IActionResult> Update()
        {
            var equipment = _equipmentRepository.GetAll();
            return View(equipment);
        }



    }
}
