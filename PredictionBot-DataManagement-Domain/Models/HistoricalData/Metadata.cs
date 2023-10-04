using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace PredictionBot_DataManagement_Domain.Models.HistoricalData;

public class Metadata
{
    [BsonId]
    [JsonIgnore]
    public ObjectId Id { get; set; }

    public string Symbol { get; set; }

    public string Interval { get; set; }

    public string ExchangeTimezone { get; set; }

    public string Exchange { get; set; }

    public string MarketIdentifierCode { get; set; }

    public string AssetClassType { get; set; }
}