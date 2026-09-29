namespace DiveDeep.Models
{
    public class DivingConditions
    {
        public string? Location { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public double WindSpeed { get; set; }

        public double Precipitation { get; set; }

        public int WeatherCode { get; set; }

        public bool IsThunderstorm { get; set; }

        public double? WaveHeight { get; set; }

        public double? WaterTemperature { get; set; }

        public bool IsSuitableForDiving { get; set; }

        public string? RecommendedSuit { get; set; }

        public List<string> Reasons { get; set; } = new List<string>();
    }
}
