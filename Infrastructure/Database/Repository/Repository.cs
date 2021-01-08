using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Infrastructure.Database
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbContext DbContext { get; set; }
        public DbSet<TEntity> DbSet
        {
            get
            {
                return DbContext.Set<TEntity>();
            }
        }

        public Repository(ApplicationDbContext dbContext)
        {
        }


        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="entity"></param>
        public void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        /// <summary>
        /// Add an entity
        /// </summary>
        /// <param name="entity"></param>
        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
        }

        /// <summary>
        /// Add many entities
        /// </summary>
        /// <param name="entities"></param>
        public void AddRange(IEnumerable<TEntity> entities)
        {
            DbSet.AddRange(entities);
        }

        /// <summary>
        /// Add many entities
        /// </summary>
        /// <param name="entities"></param>
        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await DbSet.AddRangeAsync(entities);
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entity"></param>
        public void Delete(TEntity entity)
        {
            DbSet.Remove(entity);
        }

        /// <summary>
        /// Delete many entities
        /// </summary>
        /// <param name="entities"></param>
        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            DbSet.RemoveRange(entities);
        }

        /// <summary>
        /// Get entities from sql string
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> FromSqlQuery(string sql, bool allowTracking = true)
        {
            if (allowTracking)
            {
                return DbSet.FromSqlRaw(sql).ToList();
            }
            else
            {
                return DbSet.FromSqlRaw(sql).AsNoTracking().ToList();
            }
        }

        /// <summary>
        /// Get entities from sql string
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> FromSqlQueryAsync(string sql, bool allowTracking = true)
        {
            if (allowTracking)
            {
                return await DbSet.FromSqlRaw(sql).ToListAsync();
            }
            else
            {
                return await DbSet.FromSqlRaw(sql).AsNoTracking().ToListAsync();
            }
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        public IEnumerable<TEntity> GetAll(bool allowTracking = true)
        {
            return DbSet.AsNoTracking().ToList();
        }

        /// <summary>
        /// Get all entities
        /// </summary>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool allowTracking = true)
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Get a entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        public TEntity GetById(string id, bool allowTracking = true)
        {
            return DbSet.FirstOrDefault(e => (e.GetType().GetProperty("Id").GetValue(e) as string) == id);
        }

        /// <summary>
        /// Get a entity by Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        public async Task<TEntity> GetByIdAsync(string id, bool allowTracking = true)
        {
            return await DbSet.Where(e => (e.GetType().GetProperty("Id").GetValue(e) as string) == id).FirstOrDefaultAsync();
        }

        /// <summary>
        /// Get many entities by predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="allowTracking"></param>
        /// <returns></returns>
        public IQueryable<TEntity> FindByCondition(Expression<Func<TEntity, bool>> predicate, bool allowTracking = true)
        {
            return DbSet.Where(predicate).AsNoTracking();
        }

        /// <summary>
        /// Update an entity
        /// </summary>
        /// <param name="entity"></param>
        public void Update(TEntity entity)
        {
            //DbSet.Attach(entity);
            DbContext.Entry(entity).State = EntityState.Modified;
        }

        /// <summary>
        /// Detach an entity
        /// </summary>
        /// <param name="entity"></param>
        public void Detach(TEntity entity)
        {
            DbContext.Entry(entity).State = EntityState.Detached;
        }

    }
}
