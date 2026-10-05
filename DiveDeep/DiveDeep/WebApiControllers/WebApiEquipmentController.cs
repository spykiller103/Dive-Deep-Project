using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DiveDeep.WebApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiEquipmentController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly CartService _cartService;

        public WebApiEquipmentController(
            IEquipmentRepository equipmentRepository,
            CartService cartService,
            UserManager<ApplicationUser> userManager)
        {
            _equipmentRepository = equipmentRepository;
            _cartService = cartService;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Equipment> equipment =
                await _equipmentRepository.GetAll();

            return Ok(equipment);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecific(int id)
        {
            if (id <= 0)
                return BadRequest();

            Equipment equipment =
                await _equipmentRepository.GetById(id);

            if (equipment == null)
                return NotFound();

            return Ok(equipment);
        }

        [HttpPost]
        public async Task<IActionResult> RentAsync(
            [FromQuery] int id,
            string start,
            string end,
            string? size,
            IFormCollection form,
            string userId)
        {
            Equipment equipmentToBeAdded =
                await _equipmentRepository.GetById(id);

            if (equipmentToBeAdded == null)
                return NotFound();

            DateTime startDate, endDate;

            bool _start = DateTime.TryParseExact(
                start,
                new[] { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" },
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out startDate);

            bool _end = DateTime.TryParseExact(
                end,
                new[] { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" },
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out endDate);

            if (!_start || !_end)
            {
                return BadRequest();
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

            return Ok();
        }
    }
}