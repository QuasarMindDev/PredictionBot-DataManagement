using Microsoft.Extensions.Options;
using MongoDB.Driver;
using PredictionBot_DataManagement_Domain.Configuration;

namespace PredictionBot_DataManagement_Infrastructure.Common
{
    public class MongoDbContext : IMongoContext
    {
        private readonly MongoClient _client;

        public MongoDbContext(IOptions<DatabaseConnection> dbOptions)
        {
            var settings = dbOptions.Value;
            _client = new MongoClient(settings.ConnectionString);
            Database = _client.GetDatabase(settings.DatabaseName);
        }

        public IMongoClient Client
        { get { return _client; } }

        public IMongoDatabase Database { get; }
    }
}