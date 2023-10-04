using PredictionBot_DataManagement_Domain.Models.HistoricalData;

namespace PredictionBot_DataManagement_Domain.Dtos.HistoricalData
{
    public record HistoricalDataDatabaseDto
    {
        public IEnumerable<MarketData> MarketData { get; init; }
        public Metadata Metadata { get; init; }
    }
}