namespace PredictionBot_DataManagement_Domain.Models;

public class Parameter
{
    public virtual ICollection<CalculatedParametersHistoricalData> CalculatedParametersHistoricalData { get; set; } = new List<CalculatedParametersHistoricalData>();
    public string ParameterId { get; set; } = null!;
    public string ParameterName { get; set; } = null!;
}