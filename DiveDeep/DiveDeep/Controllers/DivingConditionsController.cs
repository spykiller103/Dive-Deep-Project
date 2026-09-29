using DiveDeep.Models;
using DiveDeep.Service;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.Controllers
{
    public class DivingConditionsController : Controller
    {
        private readonly IDivingConditionsHttpService _openMeteoService;

        public DivingConditionsController(IDivingConditionsHttpService openMeteoService)
        {
            _openMeteoService = openMeteoService;
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

            OpenMeteoLocation? result =
                await _openMeteoService.GetLocationByNameAsync(location);

            if (result == null)
            {
                ViewBag.Message = "Lokationen kunne ikke findes.";
                return View("Index");
            }

            OpenMeteoWeatherResponse? weather = await _openMeteoService.GetWeatherAsync(result.Latitude, result.Longitude);

            OpenMeteoMarineResponse? marine = await _openMeteoService.GetMarineAsync(result.Latitude, result.Longitude);

            bool isThunderstorm =
                weather?.Current?.WeatherCode == 95 || //tordenvejr
                weather?.Current?.WeatherCode == 96 || //tordenvejr
                weather?.Current?.WeatherCode == 99; //tordenvejr

            List<string> reasons = new List<string>();

            if (weather?.Current?.WindSpeed >= 8)
            {
                reasons.Add("Vindhastigheden er for høj.");
            }

            if (marine?.Current?.WaveHeight >= 1.5)
            {
                reasons.Add("Bølgehøjden er for høj.");
            }

            if (weather?.Current?.Precipitation >= 2)
            {
                reasons.Add("Der er for meget nedbør.");
            }

            if (isThunderstorm)
            {
                reasons.Add("Der er tordenvejr. Al dykning frarådes.");
            }

            bool isSuitableForDiving = reasons.Count == 0;

            string? recommendedSuit = null;

            if (marine?.Current?.WaterTemperature != null)
            {
                double waterTemperature = marine.Current.WaterTemperature.Value;

                if (waterTemperature > 24)
                {
                    recommendedSuit = "Våddragt (3mm)";
                }
                else if (waterTemperature >= 18)
                {
                    recommendedSuit = "Våddragt (5mm)";
                }
                else if (waterTemperature >= 10)
                {
                    recommendedSuit = "Våddragt (7mm)";
                }
                else
                {
                    recommendedSuit = "Tørdragt";
                }
            }

            ViewBag.LocationName = result.Name;
            ViewBag.Latitude = result.Latitude;
            ViewBag.Longitude = result.Longitude;

            ViewBag.WindSpeed = weather?.Current?.WindSpeed;
            ViewBag.Precipitation = weather?.Current?.Precipitation;
            ViewBag.WeatherCode = weather?.Current?.WeatherCode;

            ViewBag.WaveHeight = marine?.Current?.WaveHeight;
            ViewBag.WaterTemperature = marine?.Current?.WaterTemperature;

            ViewBag.IsThunderstorm = isThunderstorm;

            ViewBag.IsSuitableForDiving = isSuitableForDiving;
            ViewBag.Reasons = reasons;

            ViewBag.RecommendedSuit = recommendedSuit;

            return View("Index");
        }

        [HttpGet]
        public async Task<IActionResult> SearchByCords(double latitude, double longitude)
        {
            if (latitude == null || longitude == null)
            {
                ViewBag.Message = "Du skal indtaste koordinator.";
                return View("Index");
            }

            OpenMeteoMarineResponse? result =await _openMeteoService.GetLocationByCordsAsync(latitude, longitude);

            if (result == null)
            {
                ViewBag.Message = "Lokationen kunne ikke findes.";
                return View("Index");
            }

            OpenMeteoWeatherResponse? weather = await _openMeteoService.GetWeatherAsync(latitude, longitude);

            OpenMeteoMarineResponse? marine = await _openMeteoService.GetMarineAsync(latitude, longitude);

            bool isThunderstorm =
                weather?.Current?.WeatherCode == 95 || //tordenvejr
                weather?.Current?.WeatherCode == 96 || //tordenvejr
                weather?.Current?.WeatherCode == 99; //tordenvejr

            List<string> reasons = new List<string>();

            if (weather?.Current?.WindSpeed >= 8)
            {
                reasons.Add("Vindhastigheden er for høj.");
            }

            if (marine?.Current?.WaveHeight >= 1.5)
            {
                reasons.Add("Bølgehøjden er for høj.");
            }

            if (weather?.Current?.Precipitation >= 2)
            {
                reasons.Add("Der er for meget nedbør.");
            }

            if (isThunderstorm)
            {
                reasons.Add("Der er tordenvejr. Al dykning frarådes.");
            }

            bool isSuitableForDiving = reasons.Count == 0;

            string? recommendedSuit = null;

            if (marine?.Current?.WaterTemperature != null)
            {
                double waterTemperature = marine.Current.WaterTemperature.Value;

                if (waterTemperature > 24)
                {
                    recommendedSuit = "Våddragt (3mm)";
                }
                else if (waterTemperature >= 18)
                {
                    recommendedSuit = "Våddragt (5mm)";
                }
                else if (waterTemperature >= 10)
                {
                    recommendedSuit = "Våddragt (7mm)";
                }
                else
                {
                    recommendedSuit = "Tørdragt";
                }
            }
            ViewBag.LocationName = $"{latitude}, {longitude}";

            ViewBag.Latitude = latitude;
            ViewBag.Longitude = longitude;

            ViewBag.WindSpeed = weather?.Current?.WindSpeed;
            ViewBag.Precipitation = weather?.Current?.Precipitation;
            ViewBag.WeatherCode = weather?.Current?.WeatherCode;

            ViewBag.WaveHeight = marine?.Current?.WaveHeight;
            ViewBag.WaterTemperature = marine?.Current?.WaterTemperature;

            ViewBag.IsThunderstorm = isThunderstorm;

            ViewBag.IsSuitableForDiving = isSuitableForDiving;
            ViewBag.Reasons = reasons;

            ViewBag.RecommendedSuit = recommendedSuit;

            return View("Index");
        }
    }
}
