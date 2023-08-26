﻿using Core.Entities;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IBaseRepository<T> where T : class, IEntity, new()
    {
        Task<IEnumerable<T>> GetListAsync();

        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);
        Task<List<T>> Include(params Expression<Func<T, object>>[] includes);
    }
}
