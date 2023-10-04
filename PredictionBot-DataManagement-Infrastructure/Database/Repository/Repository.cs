using MongoDB.Driver;
using System.Linq.Expressions;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _databaseCollection;

        public Repository(IMongoDatabase database, string collectionName)
        {
            _databaseCollection = database.GetCollection<T>(collectionName);
        }

        public virtual async Task AddAsync(T entity)
        {
            await _databaseCollection.InsertOneAsync(entity);
        }

        public virtual async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _databaseCollection.InsertManyAsync(entities);
        }

        public virtual async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression)
        {
            return (await _databaseCollection.FindAsync(expression)).ToList();
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return (await _databaseCollection.FindAsync(_ => true)).ToList();
        }

        public virtual async Task RemoveOneAsync(Expression<Func<T, bool>> expression)
        {
            await _databaseCollection.FindOneAndDeleteAsync(expression);
        }

        public virtual async Task RemoveManyAsync(Expression<Func<T, bool>> expression)
        {
            await _databaseCollection.DeleteManyAsync(expression);
        }

        public virtual async Task UpdateOneAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> update)
        {
            await _databaseCollection.UpdateOneAsync(expression, update);
        }

        public virtual async Task UpdateManyAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> update)
        {
            await _databaseCollection.UpdateManyAsync(expression, update);
        }
    }
}