using CheckSPNs.Data.EF.Abstract;
using CheckSPNs.Data.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace CheckSPNs.Data.EF.Implementations;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly CheckSPNsContext _context;

    public Repository(CheckSPNsContext context)
    {
        _context = context;
    }

    public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>> expression = null)
    {
        if (expression == null)
        {
            return await _context.Set<T>().ToListAsync();
        }
        return await _context.Set<T>().Where(expression).ToListAsync();
    }

    public async Task<T> GetByIdAsync(object id)
    {
        return await _context.Set<T>().FindAsync(id);
    }

    public async Task<T> GetSingleByConditionAsync(Expression<Func<T, bool>> expression)
    {
        return await _context.Set<T>().Where(expression).FirstOrDefaultAsync();
    }

    public void Delete(T entity)
    {
        EntityEntry entry = _context.Entry(entity);
        entry.State = EntityState.Deleted;
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

    public async Task InsertAsync(List<T> entities)
    {
        await _context.Set<T>().AddRangeAsync(entities);
    }

    public void Update(T entity)
    {
        EntityEntry entry = _context.Entry(entity);
        entry.State = EntityState.Modified;
    }

    public IQueryable<T> Table => _context.Set<T>();

    public async Task CommitAsync()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task RollBack()
    {
        await _context.Database.RollbackTransactionAsync();
    }

    public IQueryable<T> GetTableNoTracking()
    {
        return _context.Set<T>().AsNoTracking().AsQueryable();
    }

    public IQueryable<T> GetTableAsTracking()
    {
        return _context.Set<T>().AsQueryable();
    }
}
