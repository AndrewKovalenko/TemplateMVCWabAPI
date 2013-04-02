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
    public class BaseRepository<T, TK> : IBaseRepository<T, TK> where T : BaseEntity<TK> where TK : struct 
    {
        private ProjectTemplateDbContext _dbContext;
        private readonly IDbSet<T> _dbSet;
        private readonly IDataBaseFactory _databaseFactory;

        protected ProjectTemplateDbContext DbContext
        {
            get
            {
                return _dbContext ?? (_dbContext = _databaseFactory.GetContext());
            }
        }

        public BaseRepository(IDataBaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _dbSet = DbContext.Set<T>();
        }


        public T GetById(TK key, params Expression<Func<T, object>>[] includeExpressions)
        {
            var set = _dbSet.Where(e => e.Id.Equals(key));
            set = includeExpressions.Aggregate(set, (current, includeExpression) => current.Include(includeExpression));
            return set.SingleOrDefault();
        }

        public virtual IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions)
        {
            var set = _dbSet.AsQueryable();
            return includeExpressions.Aggregate(set, (current, includeExpression) => current.Include(includeExpression));
        }
        
        public T SaveOrUpdate(T insance)
        {
            if(insance.Id.Equals(default(TK)))
            {
                SetTimestamps(insance, isNew: true);
                _dbSet.Add(insance);
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
            _dbSet.Remove(entity);
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