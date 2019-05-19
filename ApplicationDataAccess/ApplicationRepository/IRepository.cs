using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationDataAccess.ApplicationRepository
{
    public interface IRepository<T> where T : class
    {
        T Single(Expression<Func<T, bool>> predicate = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
            bool disableTracking = true);
        IEnumerable<T> Get();
        IEnumerable<T> Get(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Add(params T[] entities);
        Task Add(IEnumerable<T> entities);
        void Delete(T entity);
        void Delete(object id);
        void Delete(params T[] entities);
        void Delete(IEnumerable<T> entities);
        void Update(T entity);
        void Update(params T[] entities);
        void Update(IEnumerable<T> entities);
        Task<T> SingleAsync(Expression<Func<T, bool>> predicate = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
          bool disableTracking = true);
        Task AddAsync(T entity, CancellationToken cancellationToken = default(CancellationToken));
        Task AddAsync(params T[] entities);
        Task<IEnumerable<T>> AddAsync(IEnumerable<T> entities, CancellationToken cancellationToken = default(CancellationToken));
        void UpdateAsync(T entity);
        Task<T> AddAsync(T t);
        int Count();
        Task<int> CountAsync();
        Task<int> DeleteAsync(T entity);
        void Dispose();
        T Find(Expression<Func<T, bool>> match);
        ICollection<T> FindAll(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAllAsync(Expression<Func<T, bool>> match);
        Task<T> FindAsync(Expression<Func<T, bool>> match);
        T Get(int id);
        IQueryable<T> GetAll();
        Task<IList<T>> GetAllAsync();
        IQueryable<T> GetAllIncluding(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetAsync(int id);
        void Save();
        Task<int> SaveAsync();
        T Update(T t, object key);
        Task<T> UpdateAsync(T t, object key);
    }
}
