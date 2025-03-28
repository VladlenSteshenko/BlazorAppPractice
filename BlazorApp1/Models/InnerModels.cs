using static BlazorApp1.Components.Pages.CountryDetails;
using System.Text.Json.Serialization;

namespace BlazorApp1
{
    public class NameInfo
    {
        [JsonPropertyName("common")]
        public string Common { get; set; }

        [JsonPropertyName("official")]
        public string Official { get; set; }
    }

    public class CurrencyInfo
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }

    public class FlagInfo
    {
        [JsonPropertyName("png")]
        public string Png { get; set; }
    }

    public class MapInfo
    {
        [JsonPropertyName("googleMaps")]
        public string GoogleMaps { get; set; }

        [JsonPropertyName("openStreetMaps")]
        public string OpenStreetMaps { get; set; }
    }
}
