using MongoDB.Driver;

namespace PredictionBot_DataManagement_Infrastructure.Common
{
    public interface IMongoContext
    {
        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }
    }
}