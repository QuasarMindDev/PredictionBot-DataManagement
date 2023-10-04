using MongoDB.Bson;
using PredictionBot_DataManagement_Domain.Models.HistoricalData;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public interface IMetadataRepository : IRepository<Metadata>
    {
        new public Task<ObjectId> AddAsync(Metadata entity);
    }
}