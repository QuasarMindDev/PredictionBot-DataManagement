using PredictionBot_DataManagement_Infrastructure.Common;
using PredictionBot_DataManagement_Infrastructure.Database.Repository;

namespace PredictionBot_DataManagement_Infrastructure.Database
{
    public class DatabaseService : IDatabaseService
    {
        private readonly IMongoContext _dbContext;

        public DatabaseService(IMongoContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IMarketDataRepository HistoricalData => new MarketDataRepository(_dbContext);
    }
}