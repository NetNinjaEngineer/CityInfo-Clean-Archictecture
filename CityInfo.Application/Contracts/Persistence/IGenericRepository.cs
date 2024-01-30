using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CityInfo.Application.Contracts.Persistence
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll(bool trackChanges, params Expression<Func<T, object>>[] includes);

        IEnumerable<T> GetAllByCondition(bool trackChanges, Expression<Func<T, bool>> expression,
            params Expression<Func<T, object>>[] includes);

        T Create(T entity);

        T Update(T entity);

        T Delete(T entity);

    }
}
