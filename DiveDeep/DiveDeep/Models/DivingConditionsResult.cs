namespace DiveDeep.Models
{
    public class DivingConditionsResult
    {
        public string? LocationName { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double? WindSpeed { get; set; }
        public double? Precipitation { get; set; }
        public int? WeatherCode { get; set; }

        public double? WaveHeight { get; set; }
        public double? WaterTemperature { get; set; }

        public bool IsThunderstorm { get; set; }
        public bool IsSuitableForDiving { get; set; }

        public List<string> Reasons { get; set; } = new();

        public string? RecommendedSuit { get; set; }
    }
}
