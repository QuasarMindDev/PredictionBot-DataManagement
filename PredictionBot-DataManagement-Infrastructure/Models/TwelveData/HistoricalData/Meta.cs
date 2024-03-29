﻿using System.Text.Json.Serialization;

namespace PredictionBot_DataManagement_Infrastructure.Models.TwelveData.HistoricalData
{
    public record Meta
    {
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("interval")]
        public string Interval { get; set; }

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("exchange_timezone")]
        public string ExchangeTimezone { get; set; }

        [JsonPropertyName("exchange")]
        public string Exchange { get; set; }

        [JsonPropertyName("mic_code")]
        public string MarketIdentifierCode { get; set; }

        [JsonPropertyName("type")]
        public string AssetClassType { get; set; }
    }
}