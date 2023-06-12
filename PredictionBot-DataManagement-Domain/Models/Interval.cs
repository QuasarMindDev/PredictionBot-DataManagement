namespace PredictionBot_DataManagement_Domain.Models;

public class Interval
{
    public virtual ICollection<HistoricalData> HistoricalData { get; set; } = new List<HistoricalData>();
    public string IntervalId { get; set; } = Guid.NewGuid().ToString();
    public string IntervalName { get; set; } = null!;
}