using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> DbSet { get; }
        DbContext DbContext { get; set; }

        #region SYNC_FUNCTION

        IEnumerable<TEntity> GetAll(bool allowTracking = true);
        TEntity GetById(string id, bool allowTracking = true);
        IEnumerable<TEntity> GetMany(Expression<Func<TEntity, bool>> predicate, bool allowTracking = true);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);

        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> FromSqlQuery(string sql, bool allowTracking = true);

        #endregion

        #region ASYNC_FUNCTION

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAllAsync(bool allowTracking = true);
        Task<TEntity> GetByIdAsync(string id, bool allowTracking = true);
        Task<IEnumerable<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> predicate, bool allowTracking = true);
        Task<IEnumerable<TEntity>> FromSqlQueryAsync(string sql, bool allowTracking = true);

        #endregion
    }
}
