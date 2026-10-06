using DiveDeep.Data;
using DiveDeep.Models;
using DiveDeep.Persistence;
using DiveDeep.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;

namespace DiveDeep.WebApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiPackagesController : ControllerBase
    {
        private readonly IPackageRepository _packageRepository;
        private readonly CartService _cartService;

        public WebApiPackagesController(IPackageRepository packageRepository, CartService cartService)
        {
            _packageRepository = packageRepository;
            _cartService = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            List<Package> packages = await _packageRepository.GetAllAsync();
            return Ok(packages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecefic(int id)
        {
            if (id <= 0)
                return BadRequest();

            Package package = await _packageRepository.GetByIdAsync(id);

            if (package == null)
                return NotFound();

            return Ok(package);
        }

        [HttpPost]
        public async Task<IActionResult> RentAsync([FromQuery] int id, string start, string end, string? size, IFormCollection form, string userId)
        {   
            Package packagesToBeAdded = await _packageRepository.GetByIdAsync(id);

            DateTime startDate, endDate;
            bool _start = DateTime.TryParseExact(start,
                new[] { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out startDate);

            bool _end = DateTime.TryParseExact(end,
                new[] { "dd/MM/yyyy", "d/M/yyyy", "dd/M/yyyy", "d/MM/yyyy" },
                CultureInfo.InvariantCulture, DateTimeStyles.None, out endDate);

            if (!_start || !_end)
            {
                int key = id;

                ModelState.AddModelError(
                    key.ToString(),
                    "Vælg venligst både start- og slutdato."
                );

                Package package = await _packageRepository.GetByIdAsync(id);

                return BadRequest("Vælg venligst både start- og slutdato.");
            }

            int days = (endDate - startDate).Days + 1;

            if (days < 1)
            {
                days = 1;
            }

            CartItem cartItem = new CartItem
            {
                Package = packagesToBeAdded,
                StartDate = startDate,
                EndDate = endDate,
                TotalDays = days,
                ApplicationUserId = userId
            };

            // Handle individual equipment sizes from the form
            List<CartItemEquipmentSize> equipmentSizes = new List<CartItemEquipmentSize>();
            foreach (string key in form.Keys)
            {
                if (key.StartsWith("equipmentSizes["))
                {
                    int startIndex = "equipmentSizes[".Length;
                    int endIndex = key.IndexOf("]");
                    string equipmentName = key.Substring(startIndex, endIndex - startIndex);
                    string selectedSize = form[key];
                    if (!string.IsNullOrWhiteSpace(selectedSize))
                    {
                        equipmentSizes.Add(new CartItemEquipmentSize
                        {
                            EquipmentName = equipmentName,
                            SelectedSize = selectedSize
                        });
                    }
                }
            }

            if (equipmentSizes.Count > 0)
            {
                cartItem.EquipmentSizes = equipmentSizes;
            }
            else if (!string.IsNullOrWhiteSpace(size))
            {
                // Fallback for backward compatibility
                cartItem.SelectedSize = size;
            }

            await _cartService.AddAsync(cartItem);
            return Ok();
        }
    }
}
