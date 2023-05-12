namespace PredictionBot_DataManagement_Domain.Models
{
    public class CalculatedParametersHistoricalData
    {
        public Guid CalculatedParameterId { get; set; }
        public string CalculatedValue { get; set; }
        public DateTime EndDate { get; set; }
        public Parameters ParameterId { get; set; }
        public DateTime StartDate { get; set; }
    }
}