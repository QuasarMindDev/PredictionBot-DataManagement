using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace PredictionBot_DataManagement_Domain.Models.HistoricalData;

public class MarketData
{
    [BsonId]
    [JsonIgnore]
    public ObjectId Id { get; set; }

    public string Open { get; set; }

    public string High { get; set; }

    public string Low { get; set; }

    public string Close { get; set; }

    public long Volume { get; set; }

    public DateTime? Datetime { get; set; }

    [JsonIgnore]
    public ObjectId MetadataId { get; set; }
}