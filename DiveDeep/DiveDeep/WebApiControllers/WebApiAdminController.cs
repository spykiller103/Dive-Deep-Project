using DiveDeep.Models;
using DiveDeep.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.WebApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiAdminController : ControllerBase
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public WebApiAdminController(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Equipment> equipment = await _equipmentRepository.GetAllAsync();

            return Ok(equipment);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecific(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Equipment equipment = await _equipmentRepository.GetByIdAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            return Ok(equipment);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _equipmentRepository.CreateEquipmentAsync(equipment);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEquipment(int id, Equipment equipment)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Equipment existingEquipment = await _equipmentRepository.GetByIdAsync(id);

            if (existingEquipment == null)
            {
                return NotFound();
            }

            equipment.EquipmentId = id;

            await _equipmentRepository.UpdateEquipmentAsync(equipment);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Equipment equipment = await _equipmentRepository.GetByIdAsync(id);

            if (equipment == null)
            {
                return NotFound();
            }

            await _equipmentRepository.DeleteEquipmentAsync(id);

            return Ok();
        }
    }
}