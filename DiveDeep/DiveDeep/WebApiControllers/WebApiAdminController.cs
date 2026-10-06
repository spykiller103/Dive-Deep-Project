using DiveDeep.DTOs;
using DiveDeep.Models;
using DiveDeep.Persistence;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.WebApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiAdminController : ControllerBase
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IEquipmentRepository _equipmentRepository;
        private readonly ICartItemRepository _cartItemRepository;

        public WebApiAdminController(IEquipmentRepository equipmentRepository, IBookingRepository bookingRepository, ICartItemRepository cartItemRepository)
        {
            _equipmentRepository = equipmentRepository;
            _bookingRepository = bookingRepository;
            _cartItemRepository = cartItemRepository;
        }

        [HttpGet("equipment")]
        public async Task<IActionResult> GetAllEquipmentAsync()
        {
            List<Equipment> equipment = await _equipmentRepository.GetAllAsync();

            return Ok(equipment);
        }

        [HttpGet("equipment/{id}")]
        public async Task<IActionResult> GetSpecificEquipmentAsync(int id)
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

        [HttpPost("equipment")]
        public async Task<IActionResult> CreateEquipmentAsync(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _equipmentRepository.CreateEquipmentAsync(equipment);

            return Ok();
        }

        [HttpPut("equipment/{id}")]
        public async Task<IActionResult> UpdateEquipmentAsync(int id, Equipment equipment)
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

        [HttpDelete("equipment/{id}")]
        public async Task<IActionResult> DeleteEquipmentAsync(int id)
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

        [HttpGet("booking")]
        public async Task<IActionResult> GetAllBookingsAsync()
        {
            List<Booking>? bookings = await _bookingRepository.GetAllAsync();

            List<BookingDTO> bookingDTOs = bookings.Adapt<List<BookingDTO>>();

            return Ok(bookingDTOs);
        }

        [HttpDelete("booking/{id}")]
        public async Task<IActionResult> DeleteBookingAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            Booking booking = await _bookingRepository.GetByIdAsync(id);

            if (booking == null)
            {
                return NotFound();
            }

            await _bookingRepository.DeleteBookingAsync(id);

            return Ok();
        }


        [HttpGet("booking/{id}")]
        public async Task<IActionResult> EditBookingDetailsAsync(int id)
        {
            var booking = await _bookingRepository.GetByIdAsync(id);
            if (booking == null)
            {
                return NotFound();
            }

            BookingDTO bookingDTO = booking.Adapt<BookingDTO>();

            return Ok(bookingDTO);
        }

        [HttpDelete("cartitem/{id}")]
        public async Task<IActionResult> DeleteCartItemAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            CartItem cartItem = await _cartItemRepository.GetByIdAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            await _cartItemRepository.DeleteAsync(id);

            return Ok();
        }

        [HttpGet("cartitem/{id}")]
        public async Task<IActionResult> GetCartItemAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            CartItem cartItem = await _cartItemRepository.GetByIdAsync(id);

            if (cartItem == null)
            {
                return NotFound();
            }

            CartItemDTO cartItemDto = cartItem.Adapt<CartItemDTO>();

            return Ok(cartItemDto);
        }

        [HttpPut("cartitem/{id}")]
        public async Task<IActionResult> UpdateBookingCartItemAsync(int id, CartItemDTO cartItemDto)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            CartItem existingCartItem = await _cartItemRepository.GetByIdAsync(id);

            if (existingCartItem == null)
            {
                return NotFound();
            }

            cartItemDto.Adapt(existingCartItem);
            existingCartItem.CartItemId = id;

            await _cartItemRepository.AdminUpdateCartItemAsync(existingCartItem);

            return Ok();
        }
    }
}