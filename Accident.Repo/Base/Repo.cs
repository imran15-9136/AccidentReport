using Accident.Models.Common;
using Accident.Repo.Abstraction.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Accident.Repo.Base
{
    public abstract class Repo<T> : IRepo<T> where T : class
    {
        DbContext _db;
        public Repo(DbContext db)
        {
            _db = db;
        }

        public virtual async Task<bool> Add(T entity)
        {
            _db.Add(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual async Task<bool> Remove(T entity)
        {
            if (entity is IDeletable)
            {
                ((IDeletable)entity).Delete();
                return await Update(entity);
            }
            _db.Remove(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public async virtual Task<IList<T>> GetAll()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public async virtual Task<T> GetFirstorDefault(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().FirstOrDefaultAsync(predicate);
        }

        public async virtual Task<T> GetById(long id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public virtual IQueryable<T> Get(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().Where(predicate).AsQueryable();
        }

        public virtual bool UpdateRange(IList<T> entity)
        {
            _db.Set<T>().UpdateRange(entity);
            return _db.SaveChanges() > 0;
        }
        public virtual async Task<bool> UpdateRangeAsync(IList<T> entity)
        {
            _db.Set<T>().UpdateRange(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public bool RemoveRange(IList<T> entity)
        {
            _db.Set<T>().RemoveRange(entity);
            return _db.SaveChanges() > 0;
        }
        public async Task<bool> RemoveRangeAsync(IList<T> entity)
        {
            _db.Set<T>().RemoveRange(entity);
            return await _db.SaveChangesAsync() > 0;
        }

        public async Task<bool> AddRangeAsync<T>(ICollection<T> entities) where T : class
        {
            await _db.AddRangeAsync(entities);
            return await _db.SaveChangesAsync() > 0;
        }

        public virtual IQueryable<T> GetAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().AsNoTracking().Where(predicate);
        }

        public virtual T GetFirstOrDefaultAsNoTracking(Expression<Func<T, bool>> predicate)
        {
            return _db.Set<T>().AsNoTracking().FirstOrDefault(predicate);
        }

        public virtual async Task<T> GetFirstOrDefaultAsNoTrackingAsync(Expression<Func<T, bool>> predicate)
        {
            return await _db.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
        }



    }
}
