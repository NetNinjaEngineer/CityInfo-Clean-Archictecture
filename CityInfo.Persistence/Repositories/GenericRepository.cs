using CityInfo.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CityInfo.Persistence.Repositories;
public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly CityInfoDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(CityInfoDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }



    public T Create(T entity)
    {
        _dbSet.Add(entity);
        return entity;
    }

    public T Delete(T entity)
    {
        _dbSet.Remove(entity);
        return entity;
    }

    public IEnumerable<T> GetAll(bool trackChanges, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;
        foreach (var include in includes)
            query = query.Include(include);

        return !trackChanges ? query.AsNoTracking() : query;
    }

    public IEnumerable<T> GetAllByCondition(bool trackChanges, Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
    {
        IQueryable<T> query = _dbSet;
        foreach (var include in includes)
            query = query.Include(include);

        return !trackChanges ?
        query.Where(expression)
        .AsNoTracking() : query.Where(expression);
    }

    public T Update(T entity)
    {
        var updatedEntity = _dbSet.Update(entity);
        return updatedEntity.Entity;
    }
}
