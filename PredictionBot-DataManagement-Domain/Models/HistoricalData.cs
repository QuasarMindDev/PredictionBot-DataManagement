namespace PredictionBot_DataManagement_Domain.Models;

public class HistoricalData
{
    public virtual ICollection<CalculatedParametersHistoricalDataMapping> CalculatedParametersHistoricalDataMappings { get; set; } = new List<CalculatedParametersHistoricalDataMapping>();
    public float ClosePrice { get; set; }
    public string DataId { get; set; } = null!;
    public DateTime Datetime { get; set; }
    public float HighPrice { get; set; }
    public virtual Interval Interval { get; set; } = null!;
    public string IntervalId { get; set; } = null!;
    public float LowPrice { get; set; }
    public float OpenPrice { get; set; }
    public virtual Symbol Symbol { get; set; } = null!;
    public string SymbolId { get; set; } = null!;
    public float Volume { get; set; }
}