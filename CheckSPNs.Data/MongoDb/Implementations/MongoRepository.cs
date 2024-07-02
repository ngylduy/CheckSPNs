using CheckSPNs.Data.MongoDb.Abstract;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace CheckSPNs.Data.MongoDb.Implementations
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoDatabase Database;
        private readonly IMongoCollection<T> DbSet;

        public MongoRepository(IMongoContext context)
        {
            Database = context.Database;
            DbSet = Database.GetCollection<T>(typeof(T).Name);
        }

        public async void Delete(object id)
        {
            await DbSet.DeleteOneAsync(FilterId(id));
        }

        public async void Delete(Expression<Func<T, bool>> expression)
        {
            await DbSet.DeleteManyAsync(expression);
        }

        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null)
            {
                return await DbSet.Find(_ => true).ToListAsync();
            }
            return await DbSet.Find(expression).ToListAsync();
        }

        public IQueryable<T> GetAll()
        {
            return DbSet.AsQueryable();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await DbSet.Find(FilterId(id)).FirstOrDefaultAsync();
        }

        public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression)
        {
            return await DbSet.Find(expression).FirstOrDefaultAsync();
        }

        public async Task InsertAsync(T entity)
        {
            await DbSet.InsertOneAsync(entity);
        }

        public async Task InsertAsync(List<T> entities)
        {
            await DbSet.InsertManyAsync(entities);
        }

        public async void Update(object id, T entity)
        {
            await DbSet.ReplaceOneAsync(FilterId(id), entity);
        }

        private static FilterDefinition<T> FilterId(object id)
        {
            return Builders<T>.Filter.Eq("_id", id);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
