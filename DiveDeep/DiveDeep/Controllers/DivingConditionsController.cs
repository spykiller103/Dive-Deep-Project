using DiveDeep.DTOs;
using DiveDeep.Models;
using DiveDeep.Service;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Globalization;

namespace DiveDeep.Controllers
{
    public class DivingConditionsController : Controller
    {
        private readonly IDivingConditionsHttpService _openMeteoService;
        private readonly IHttpClientFactory _httpClientFactory;

        public DivingConditionsController(IDivingConditionsHttpService openMeteoService, IHttpClientFactory httpClientFactory)
        {
            _openMeteoService = openMeteoService;
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SearchByLocation(string location)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            HttpResponseMessage response =
                await httpClient.GetAsync($"WebApiDivingConditions/location/{location}");

            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Message = await response.Content.ReadAsStringAsync();
                return View("Index");
            }

            DivingConditionsDTO result = await response.Content.ReadFromJsonAsync<DivingConditionsDTO>();

            ViewBag.LocationName = result.Location.Name;
            ViewBag.Latitude = result.Location.Latitude;
            ViewBag.Longitude = result.Location.Longitude;

            ViewBag.WindSpeed = result.Weather?.Current?.WindSpeed;
            ViewBag.Precipitation = result.Weather?.Current?.Precipitation;
            ViewBag.WeatherCode = result.Weather?.Current?.WeatherCode;

            ViewBag.WaveHeight = result.Marine?.Current?.WaveHeight;
            ViewBag.WaterTemperature = result.Marine?.Current?.WaterTemperature;

            ViewBag.IsThunderstorm = result.IsThunderstorm;
            ViewBag.IsSuitableForDiving = result.IsSuitableForDiving;
            ViewBag.Reasons = result.Reasons;
            ViewBag.RecommendedSuit = result.RecommendedSuit;

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SearchByCords(double latitude, double longitude)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            HttpResponseMessage response = await httpClient.GetAsync($"WebApiDivingConditions/cords/{latitude.ToString(CultureInfo.InvariantCulture)}/{longitude.ToString(CultureInfo.InvariantCulture)}");


            if (!response.IsSuccessStatusCode)
            {
                ViewBag.Message = await response.Content.ReadAsStringAsync();
                return View("Index");
            }

            DivingConditionsDTO result = await response.Content.ReadFromJsonAsync<DivingConditionsDTO>();

            ViewBag.LocationName = $"{result.Latitude}, {result.Longitude}";

            ViewBag.Latitude = result.Latitude;
            ViewBag.Longitude = result.Longitude;

            ViewBag.WindSpeed = result.Weather?.Current?.WindSpeed;
            ViewBag.Precipitation = result.Weather?.Current?.Precipitation;
            ViewBag.WeatherCode = result.Weather?.Current?.WeatherCode;

            ViewBag.WaveHeight = result.Marine?.Current?.WaveHeight;
            ViewBag.WaterTemperature = result.Marine?.Current?.WaterTemperature;

            ViewBag.IsThunderstorm = result.IsThunderstorm;
            ViewBag.IsSuitableForDiving = result.IsSuitableForDiving;
            ViewBag.Reasons = result.Reasons;
            ViewBag.RecommendedSuit = result.RecommendedSuit;

            return View("Index");
        }
    }
}