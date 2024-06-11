using CheckSPNs.Data.Abstract;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;

namespace CheckSPNs.Data
{
    public class Repository<T> : IRepository<T> where T : class
    {
        CheckSPNsContext _context;
        public Repository(CheckSPNsContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<T>> GetDataAsync(Expression<Func<T, bool>> expression = null)
        {
            if (expression == null) {
                return await _context.Set<T>().ToListAsync();
            }
            return await _context.Set<T>().Where(expression).ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public void Delete(T entity)
        {
            EntityEntry entry = _context.Entry<T>(entity);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public void Delete(Expression<Func<T, bool>> expression)
        {
            var entities = _context.Set<T>().Where(expression).ToList();
            if (entities.Count > 0)
            {
                _context.Set<T>().RemoveRange(entities);
            }
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        public async Task InsertAsync(IEnumerable<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
        }

        public void Update(T entity)
        {
            EntityEntry entry = _context.Entry<T>(entity);
            entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public virtual IQueryable<T> Table => _context.Set<T>();

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
