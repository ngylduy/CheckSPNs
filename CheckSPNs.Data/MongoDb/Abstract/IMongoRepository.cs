
using System.Linq.Expressions;

namespace CheckSPNs.Data.MongoDb.Abstract
{
    public interface IMongoRepository<T> : IDisposable where T : class
    {
        void Delete(Expression<Func<T, bool>> expression);
        void Delete(object id);
        IQueryable<T> GetAll();
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetByIdAsync(object id);
        Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression);
        Task InsertAsync(List<T> entities);
        Task InsertAsync(T entity);
        void Update(object id, T entity);
    }
}
