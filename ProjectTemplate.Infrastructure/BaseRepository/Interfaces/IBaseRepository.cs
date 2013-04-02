using System;
using System.Linq;
using System.Linq.Expressions;
using ProjectTemplate.Domain.BaseEntity;

namespace ProjectTemplate.Infrastructure.BaseRepository.Interfaces
{
    public interface IBaseRepository<T, in TK> where T: BaseEntity<TK> where TK: struct 
    {
        T GetById(TK key, params Expression<Func<T, object>>[] includeExpressions);
        IQueryable<T> GetAll(params Expression<Func<T, object>>[] includeExpressions);
        T SaveOrUpdate(T insance);
        void Delete(T instance);
    }
}