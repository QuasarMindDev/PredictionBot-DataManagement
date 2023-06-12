namespace PredictionBot_DataManagement_Domain.Models;

public class CalculatedParametersHistoricalDataMapping
{
    public virtual CalculatedParametersHistoricalData CalculatedParameter { get; set; } = null!;
    public string CalculatedParameterId { get; set; } = null!;
    public virtual HistoricalData Data { get; set; } = null!;
    public string DataId { get; set; } = null!;
    public string MappingId { get; set; } = Guid.NewGuid().ToString();
}