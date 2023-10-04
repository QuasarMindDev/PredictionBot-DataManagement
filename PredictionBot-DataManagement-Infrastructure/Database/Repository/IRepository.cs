using MongoDB.Driver;
using System.Linq.Expressions;

namespace PredictionBot_DataManagement_Infrastructure.Database.Repository
{
    public interface IRepository<T> where T : class
    {
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> expression);

        Task<IEnumerable<T>> GetAllAsync();

        Task UpdateOneAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> update);

        Task UpdateManyAsync(Expression<Func<T, bool>> expression, UpdateDefinition<T> update);

        Task RemoveManyAsync(Expression<Func<T, bool>> expression);

        Task RemoveOneAsync(Expression<Func<T, bool>> expression);
    }
}