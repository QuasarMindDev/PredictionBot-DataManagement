namespace PredictionBot_DataManagement_Domain.Models
{
    public class CalculatedParametersHistoricalDataMapping
    {
        public CalculatedParametersHistoricalData CalculatedParameterId { get; set; }
        public HistoricalData DataId { get; set; }
        public Guid MappingId { get; set; }
    }
}