﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accident.Repo.Abstraction.Base
{
    public interface IRepo<T> where T:class
    {
        Task<bool> Add(T entity);
        Task<bool> AddRangeAsync<T>(ICollection<T> entities) where T : class;
        Task<bool> Update(T entity);
        Task<bool> Remove(T entity);
        Task<IList<T>> GetAll();
        Task<T> GetById(long id);
        Task<T> GetFirstorDefault(Expression<Func<T, bool>> predicate);

        IQueryable<T> Get(Expression<Func<T, bool>> predicate);
        bool UpdateRange(IList<T> entity);
        Task<bool> UpdateRangeAsync(IList<T> entity);
        bool RemoveRange(IList<T> entity);
        Task<bool> RemoveRangeAsync(IList<T> entity);

        T GetFirstOrDefaultAsNoTracking(Expression<Func<T, bool>> predicate);
        Task<T> GetFirstOrDefaultAsNoTrackingAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAsNoTracking(Expression<Func<T, bool>> predicate);
    }
}
