using MongoDB.Bson;
using PredictionBot_DataManagement_Domain.Commons;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;
using PredictionBot_DataManagement_Infrastructure.Common;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public class MetadataDataRepository : Repository<Metadata>, IMetadataRepository
    {
        private const string CollectionName = Constant.MetadataCollectionName;

        public MetadataDataRepository(IMongoContext context) : base(context.Database, CollectionName)
        {
        }

        public override async Task<ObjectId> AddAsync(Metadata entity)
        {
            var medatadataDatabaseValue = (await base.FindAsync(item => item.Symbol == entity.Symbol &&
                                                                       item.Interval == entity.Interval &&
                                                                       item.Exchange == entity.Exchange)).FirstOrDefault();
            if (medatadataDatabaseValue == null)
            {
                await base.AddAsync(entity);
                return entity.Id;
            }
            return medatadataDatabaseValue.Id;
        }
    }
}