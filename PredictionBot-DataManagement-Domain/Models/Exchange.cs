namespace PredictionBot_DataManagement_Domain.Models
{
    public class Exchange
    {
        public Guid ExchangeId { get; set; }
        public string ExchangeName { get; set; }
        public string Timezone { get; set; }
    }
}