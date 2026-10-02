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
        private readonly IBookingRepository _bookingRepository;

        public AdminController(IEquipmentRepository equipmentRepository, IBookingRepository bookingRepository)
        {

            _equipmentRepository = equipmentRepository;
            _bookingRepository = bookingRepository;
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
        [HttpGet]
        public async Task<IActionResult> EditBooking()
        {
            List<Booking> bookings = await _bookingRepository.GetAllBookingsForAdminAsync();
            return View(bookings);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipmentAsync(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {

                return View("Create", equipment);
            }

            await _equipmentRepository.CreateEquipmentAsync(equipment);

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
        public async Task<IActionResult> UpdateEquipmentAsync(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return View(equipment);
            }

            await _equipmentRepository.UpdateEquipmentAsync(equipment);

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteEquipmentAsync(int id)
        {
            await _equipmentRepository.DeleteEquipmentAsync(id);

            return RedirectToAction(nameof(Update));
        }
        [HttpPost]
        public async Task<IActionResult> DeleteBookingAsync(int id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
            return RedirectToAction(nameof(EditBooking));
        }
        [HttpGet]
        public async Task<IActionResult> EditBookingDetails(int id)
        {
            Booking? booking = await _bookingRepository.GetBookingByIdAsync(id);
            if(booking == null)
            {
                return NotFound();
            }
            return View(booking);
        }

        
    }
}
