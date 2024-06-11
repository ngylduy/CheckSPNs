using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CheckSPNs.Data.Abstract
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> Table { get; }

        Task CommitAsync();
        void Delete(T entity);
        void Delete(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(object id);
        Task<IEnumerable<T>> GetDataAsync(Expression<Func<T, bool>> expression = null);
        Task InsertAsync(T entity);
        Task InsertAsync(IEnumerable<T> entities);
        void Update(T entity);
    }
}
