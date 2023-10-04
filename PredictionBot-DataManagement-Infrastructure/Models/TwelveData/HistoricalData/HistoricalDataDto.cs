using System.Text.Json.Serialization;

namespace PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData
{
    public record HistoricalDataDto
    {
        [JsonPropertyName("meta")]
        public Meta Meta { get; set; }

        [JsonPropertyName("values")]
        public Value[] Values { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}