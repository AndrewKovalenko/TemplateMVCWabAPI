using ProjectTemplate.Domain.BaseEntity;
using ProjectTemplate.Infrastructure.BaseRepository.Interfaces;
using ProjectTemplate.Infrastructure.DataBaseContext.Interfaces;

namespace ProjectTemplate.Infrastructure.BaseRepository
{
    public class Repository<T> : BaseRepository<T, int>, IRepository<T> where T : BaseEntity<int>
    {
        public Repository(IDataBaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}