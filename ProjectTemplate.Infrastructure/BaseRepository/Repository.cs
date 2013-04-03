using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using ProjectTemplate.Domain.BaseEntity;
using ProjectTemplate.Infrastructure.BaseRepository.Interfaces;
using ProjectTemplate.Infrastructure.DataBaseContext.Interfaces;

namespace ProjectTemplate.Infrastructure.BaseRepository
{
    public class Repository<T> : BaseRepository<T, int>, IRepository<T> where T : BaseEntity<int>
    {
        public Repository(IDataBaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public override T GetById(int key, params Expression<Func<T, object>>[] includeExpressions)
        {
            var set = DbSet.Where(e => e.Id.Equals(key));
            set = includeExpressions.Aggregate(set, (current, includeExpression) => current.Include(includeExpression));
            return set.SingleOrDefault();
        }
    }
}