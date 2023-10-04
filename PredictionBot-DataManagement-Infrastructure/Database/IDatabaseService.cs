using PredictionBot_DataManagement_Infrastructure.Database.Repository;

namespace PredictionBot_DataManagement_Infrastructure.Database
{
    public interface IDatabaseService
    {
        public IMarketDataRepository HistoricalData { get; }
    }
}