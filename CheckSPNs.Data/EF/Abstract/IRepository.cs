using System.Linq.Expressions;

namespace CheckSPNs.Data.EF.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Table { get; }

        Task CommitAsync();
        Task RollBack();
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(object id);
        Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null);
        Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression = null);
        Task InsertAsync(T entity);
        Task InsertAsync(List<T> entities);
        void Update(T entity);

        IQueryable<T> GetTableNoTracking();
        IQueryable<T> GetTableAsTracking();
    }
}
