namespace PredictionBot_DataManagement_Domain.Models;

public class Symbol
{
    public virtual Currency Currency { get; set; } = null!;
    public string CurrencyId { get; set; } = null!;
    public virtual Exchange Exchange { get; set; } = null!;
    public string ExchangeId { get; set; } = null!;
    public virtual ICollection<HistoricalData> Historicaldata { get; set; } = new List<HistoricalData>();
    public string SymbolId { get; set; } = Guid.NewGuid().ToString()!;
    public string SymbolName { get; set; } = null!;
}