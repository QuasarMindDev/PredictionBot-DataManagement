namespace PredictionBot_DataManagement_Domain.Models
{
    public class HistoricalData
    {
        public string ClosePrice { get; set; }
        public Guid DataId { get; set; }
        public DateTime DateTime { get; set; }
        public string HighPrice { get; set; }
        public Interval IntervalId { get; set; }
        public string LowPrice { get; set; }
        public string OpenPrice { get; set; }
        public Symbol SymbolId { get; set; }
        public string Volume { get; set; }
    }
}