using DiveDeep.Models;
using DiveDeep.Service;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class DivingConditionsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public DivingConditionsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> SearchByLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
            {
                ViewBag.Message = "Du skal indtaste en lokation.";
                return View("Index");
            }

            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                var response = await httpClient.GetAsync(
                    $"WebApiDivingConditions/location?location={Uri.EscapeDataString(location)}");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Message = await response.Content.ReadAsStringAsync();
                    return View("Index");
                }

                var result = await response.Content
                    .ReadFromJsonAsync<DivingConditionsResult>();

                if (result == null)
                {
                    ViewBag.Message = "Der kunne ikke hentes dykkerforhold.";
                    return View("Index");
                }

                ViewBag.LocationName = result.LocationName;
                ViewBag.Latitude = result.Latitude;
                ViewBag.Longitude = result.Longitude;

                ViewBag.WindSpeed = result.WindSpeed;
                ViewBag.Precipitation = result.Precipitation;
                ViewBag.WeatherCode = result.WeatherCode;

                ViewBag.WaveHeight = result.WaveHeight;
                ViewBag.WaterTemperature = result.WaterTemperature;

                ViewBag.IsThunderstorm = result.IsThunderstorm;

                ViewBag.IsSuitableForDiving = result.IsSuitableForDiving;
                ViewBag.Reasons = result.Reasons;

                ViewBag.RecommendedSuit = result.RecommendedSuit;

                return View("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SearchByCords(double latitude, double longitude)
        {
            using var httpClient = _httpClientFactory.CreateClient("Api");

            try
            {
                var response = await httpClient.GetAsync(
                    $"WebApiDivingConditions/cords?latitude={latitude}&longitude={longitude}");

                if (!response.IsSuccessStatusCode)
                {
                    ViewBag.Message = await response.Content.ReadAsStringAsync();
                    return View("Index");
                }

                var result = await response.Content
                    .ReadFromJsonAsync<DivingConditionsResult>();

                if (result == null)
                {
                    ViewBag.Message = "Der kunne ikke hentes dykkerforhold.";
                    return View("Index");
                }

                ViewBag.LocationName = result.LocationName;
                ViewBag.Latitude = result.Latitude;
                ViewBag.Longitude = result.Longitude;

                ViewBag.WindSpeed = result.WindSpeed;
                ViewBag.Precipitation = result.Precipitation;
                ViewBag.WeatherCode = result.WeatherCode;

                ViewBag.WaveHeight = result.WaveHeight;
                ViewBag.WaterTemperature = result.WaterTemperature;

                ViewBag.IsThunderstorm = result.IsThunderstorm;

                ViewBag.IsSuitableForDiving = result.IsSuitableForDiving;
                ViewBag.Reasons = result.Reasons;

                ViewBag.RecommendedSuit = result.RecommendedSuit;

                return View("Index");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
