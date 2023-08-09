﻿using Entities.Abstract;
using System.Linq.Expressions;

namespace DataAccess
{
    public interface IBaseRepository<T> where T : class , IEntity , new()   
    {
        Task<IEnumerable<T>> GetListAsync(Expression<Func<T, bool>> filter = null);

        Task<T> GetAsync(Expression<Func<T, bool>> filter);

        Task<T> AddAsync(T entity);

        Task<T> UpdateAsync(T entity);

        Task<bool> DeleteAsync(int id);
        Task<List<T>> Include(params Expression<Func<T, object>>[] includes);
    }
}
