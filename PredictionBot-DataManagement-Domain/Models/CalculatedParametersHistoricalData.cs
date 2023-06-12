namespace PredictionBot_DataManagement_Domain.Models;

public class CalculatedParametersHistoricalData
{
    public string CalculatedParameterId { get; set; } = Guid.NewGuid().ToString();
    public virtual ICollection<CalculatedParametersHistoricalDataMapping> CalculatedParametersHistoricalDataMappings { get; set; } = new List<CalculatedParametersHistoricalDataMapping>();
    public float CalculatedValue { get; set; }
    public DateTime EndDate { get; set; }
    public virtual Parameter Parameter { get; set; } = null!;
    public string ParameterId { get; set; } = null!;
    public DateTime StartDate { get; set; }
}