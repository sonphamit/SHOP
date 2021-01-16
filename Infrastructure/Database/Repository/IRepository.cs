using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public interface IRepository<TEntity> where TEntity : class
    {
        DbSet<TEntity> DbSet { get; }
        DbContext DbContext { get; set; }

        #region SYNC_FUNCTION

        IQueryable<TEntity> Query(
            Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
        );
        IEnumerable<TEntity> GetAll(bool allowTracking = true);
        IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate, bool allowTracking = true);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void Detach(TEntity entity);
        void Delete(TEntity entity);
        void DeleteRange(IEnumerable<TEntity> entities);
        IEnumerable<TEntity> FromSqlQuery(string sql, bool allowTracking = true);

        #endregion

        #region ASYNC_FUNCTION

        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> GetAllAsync(bool allowTracking = true);
        Task<IEnumerable<TEntity>> FromSqlQueryAsync(string sql, bool allowTracking = true);

        #endregion
    }
}
