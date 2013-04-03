using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ProjectTemplate.Domain.BaseEntity;
using ProjectTemplate.Infrastructure.BaseRepository.Interfaces;
using ProjectTemplate.Infrastructure.DataBaseContext;
using ProjectTemplate.Infrastructure.DataBaseContext.Interfaces;

namespace ProjectTemplate.Infrastructure.BaseRepository
{
    public abstract class BaseRepository<T, TK> : IBaseRepository<T, TK> where T : BaseEntity<TK> where TK : struct 
    {
        private ProjectTemplateDbContext _dbContext;
        protected readonly IDbSet<T> DbSet;
        private readonly IDataBaseFactory _databaseFactory;

        protected ProjectTemplateDbContext DbContext
        {
            get
            {
                return _dbContext ?? (_dbContext = _databaseFactory.GetContext());
            }
        }

        protected BaseRepository(IDataBaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            DbSet = DbContext.Set<T>();
        }


        public abstract T GetById(TK key, params Expression<Func<T, object>>[] includeExpressions);
        
        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            var set = DbSet.AsQueryable();
            return includeExpressions.Aggregate(set, (current, includeExpression) => current.Include(includeExpression));
        }
        
        public T SaveOrUpdate(T insance)
        {
            if(insance.Id.Equals(default(TK)))
            {
                SetTimestamps(insance, isNew: true);
                DbSet.Add(insance);
            }
            else
            {
                SetTimestamps(insance, isNew: false);
                _dbContext.Entry(insance).State = EntityState.Modified;
            }

            _dbContext.SaveChanges();

            return insance;
        }

        public virtual void Delete(T entity)
        {
            DbSet.Remove(entity);
            _dbContext.SaveChanges();
        }

        protected void SetTimestamps(T entity, bool isNew)
        {
            if (entity is BaseEntityWithTimestamps<TK>)
            {
                (entity as BaseEntityWithTimestamps<TK>).UpdatedAt = DateTime.Now.ToUniversalTime();
                if (isNew)
                    (entity as BaseEntityWithTimestamps<TK>).CreatedAt = DateTime.Now.ToUniversalTime();
            }
        }
    }
}