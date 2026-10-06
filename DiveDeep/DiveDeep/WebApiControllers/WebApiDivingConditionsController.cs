using DiveDeep.DTOs;
using DiveDeep.Models;
using DiveDeep.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiveDeep.WebApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebApiDivingConditionsController : ControllerBase
    {
        private readonly IDivingConditionsHttpService _openMeteoService;

        public WebApiDivingConditionsController(
            IDivingConditionsHttpService openMeteoService)
        {
            _openMeteoService = openMeteoService;
        }

        [HttpGet("location/{location}")]
        public async Task<IActionResult> SearchByLocation(string location)
        {
            if (string.IsNullOrWhiteSpace(location))
                return BadRequest("Du skal indtaste en lokation.");


            OpenMeteoLocation? result = await _openMeteoService.GetLocationByNameAsync(location);

            if (result == null)
                return BadRequest("Lokationen kunne ikke findes.");

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

            return Ok(new
            {
                Location = result,
                Weather = weather,
                Marine = marine,
                IsThunderstorm = isThunderstorm,
                IsSuitableForDiving = isSuitableForDiving,
                Reasons = reasons,
                RecommendedSuit = recommendedSuit
            });
        }

        [HttpGet("cords/{latitude}/{longitude}")]
        public async Task<IActionResult> SearchByCords(double latitude, double longitude)
        {
            OpenMeteoMarineResponse? result =
                await _openMeteoService.GetLocationByCordsAsync(latitude, longitude);

            if (result == null)
                return BadRequest("Lokationen kunne ikke findes.");

            OpenMeteoWeatherResponse? weather =
                await _openMeteoService.GetWeatherAsync(latitude, longitude);

            OpenMeteoMarineResponse? marine =
                await _openMeteoService.GetMarineAsync(latitude, longitude);

            bool isThunderstorm =
                weather?.Current?.WeatherCode == 95 ||
                weather?.Current?.WeatherCode == 96 ||
                weather?.Current?.WeatherCode == 99;

            List<string> reasons = new List<string>();

            if (weather?.Current?.WindSpeed >= 8)
                reasons.Add("Vindhastigheden er for høj.");

            if (marine?.Current?.WaveHeight >= 1.5)
                reasons.Add("Bølgehøjden er for høj.");

            if (weather?.Current?.Precipitation >= 2)
                reasons.Add("Der er for meget nedbør.");

            if (isThunderstorm)
                reasons.Add("Der er tordenvejr. Al dykning frarådes.");

            bool isSuitableForDiving = reasons.Count == 0;

            string? recommendedSuit = null;

            if (marine?.Current?.WaterTemperature != null)
            {
                double waterTemperature = marine.Current.WaterTemperature.Value;

                if (waterTemperature > 24)
                    recommendedSuit = "Våddragt (3mm)";

                else if (waterTemperature >= 18)
                    recommendedSuit = "Våddragt (5mm)";

                else if (waterTemperature >= 10)
                    recommendedSuit = "Våddragt (7mm)";

                else
                    recommendedSuit = "Tørdragt";
            }

            DivingConditionsDTO divingConditions = new DivingConditionsDTO
            {
                Latitude = latitude,
                Longitude = longitude,
                Location = null,
                Weather = weather,
                Marine = marine,
                IsThunderstorm = isThunderstorm,
                IsSuitableForDiving = isSuitableForDiving,
                Reasons = reasons,
                RecommendedSuit = recommendedSuit
            };

            return Ok(divingConditions);
        }
    }
}
