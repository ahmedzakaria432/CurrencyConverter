using Core.Shared;
using Infrastructure.Peresistence.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Peresistence.Shared
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        
        protected readonly DbSet<TEntity> dbSet;
        private readonly ApplicationDbContext dbContext;

        public Repository(ApplicationDbContext dbContext)
        {
            
            dbSet=dbContext.Set<TEntity>();
            this.dbContext = dbContext;
        }
        public virtual Task<TEntity> DeleteAsync(TEntity entity)
        {
            
          return Task.FromResult( dbSet.Remove(entity).Entity);
        }

        public IQueryable<TEntity> GetAsQueryable()
        {
           return dbSet.AsQueryable();
        }

        public virtual async Task<TEntity?> GetByIdAsync(Guid id)
        {
            return await dbSet.AsQueryable().SingleOrDefaultAsync(e => e.Id == id);
        }

        public Task<IQueryable<TEntity>> GetRangeAsync(Expression<Func<TEntity, bool>>? expression = null, int pageNumber = 1, int pageSize = int.MaxValue)
        {

            return Task.FromResult(expression is null ? dbSet.AsNoTracking().Skip((pageNumber - 1) * pageSize).Take(pageSize)
                : dbSet.AsNoTracking().Where(expression).Skip((pageNumber - 1) * pageSize).Take(pageSize));
        }

        public async Task<TEntity> InsertAsync(TEntity entity)
        {
            entity.Id = Guid.NewGuid();
            ;
            return (await dbSet.AddAsync(entity)).Entity;
        }

        public Task<TEntity> UpdateAsync(TEntity entity)
        {
           return Task.FromResult(dbSet.Update(entity).Entity);
        }
    }
}
