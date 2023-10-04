namespace PredictionBot_DataManagement_Domain.Dtos.HistoricalData
{
    public record HistoricalDataRequestDto
    {
        public string Symbol { get; set; }

        public string Interval { get; set; }

        public string Exchange { get; set; }

        public string InitialDate { get; set; }

        public string FinalDate { get; set; }
    }
}