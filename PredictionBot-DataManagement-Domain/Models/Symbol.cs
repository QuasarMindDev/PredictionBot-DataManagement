namespace PredictionBot_DataManagement_Domain.Models
{
    public class Symbol
    {
        public Currency CurrencyId { get; set; }
        public Exchange ExchangeId { get; set; }
        public Guid SymbolId { get; set; }
        public string SymbolName { get; set; }
    }
}