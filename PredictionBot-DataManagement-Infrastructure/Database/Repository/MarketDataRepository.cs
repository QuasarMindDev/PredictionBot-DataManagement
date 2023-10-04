using PredictionBot_DataManagement_Domain.Commons;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Common;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public class MarketDataRepository : Repository<MarketData>, IMarketDataRepository
    {
        private const string CollectionName = Constant.MarketDataCollectionName;

        public MarketDataRepository(IMongoContext context) : base(context.Database, CollectionName)
        {
        }

        public override async Task AddAsync(MarketData entity)
        {
            var databaseMarketData = (await base.FindAsync(item => item.MetadataId == entity.MetadataId &&
                                                                   item.Datetime.Equals(entity.Datetime))).FirstOrDefault();
            if (databaseMarketData is null)
            {
                await base.AddAsync(entity);
            }
        }
    }
}