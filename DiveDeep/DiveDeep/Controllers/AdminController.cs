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

        private readonly IAdminService _adminService;
        private readonly IEquipmentRepository _equipmentRepository;

        public AdminController(IAdminService adminService, IEquipmentRepository equipmentRepository)
        {
            _adminService = adminService;
            _equipmentRepository = equipmentRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> CreateEquipment()
        {
            return View();
        }
        public async Task<IActionResult> UpdateEquipment()
        {
            var equipment = _equipmentRepository.GetAll();
            return View(equipment);
        }



    }
}
