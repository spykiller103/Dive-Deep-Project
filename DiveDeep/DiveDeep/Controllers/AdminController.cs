using DiveDeep.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;

namespace DiveDeep.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                List<Equipment> equipment = await httpClient.GetFromJsonAsync<List<Equipment>>("WebApiAdmin");

                return View(equipment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateEquipment(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", equipment);
            }

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.PostAsJsonAsync("WebApiAdmin", equipment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> UpdateEquipment(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                Equipment equipment = await httpClient.GetFromJsonAsync<Equipment>($"WebApiAdmin/{id}");

                if (equipment == null)
                {
                    return NotFound();
                }

                return View(equipment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdateEquipment(Equipment equipment)
        {
            if (!ModelState.IsValid)
            {
                return View(equipment);
            }

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.PutAsJsonAsync($"WebApiAdmin/{equipment.EquipmentId}",equipment);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> DeleteEquipment(int id)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                await httpClient.DeleteAsync($"WebApiAdmin/{id}");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction(nameof(Update));
        }
    }
}