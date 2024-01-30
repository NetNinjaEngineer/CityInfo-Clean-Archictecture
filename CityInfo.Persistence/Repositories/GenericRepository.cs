using CityInfo.Application.Contracts.Persistence;
using System.Linq.Expressions;

namespace CityInfo.Persistence.Repositories;
public class GenericRepository<T>(CityInfoDbContext context)
    : IGenericRepository<T> where T : class
{
    private readonly CityInfoDbContext _context = context;

    public T Create(T entity)
    {
        throw new NotImplementedException();
    }

    public T Delete(T entity)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAll(bool trackChanges, params Expression<Func<T, object>>[] includes)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<T> GetAllByCondition(bool trackChanges, Expression<Func<T, bool>> expression, params Expression<Func<T, object>>[] includes)
    {
        throw new NotImplementedException();
    }

    public T Update(T entity)
    {
        throw new NotImplementedException();
    }
}
