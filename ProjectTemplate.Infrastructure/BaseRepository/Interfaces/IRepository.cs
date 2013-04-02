using ProjectTemplate.Domain.BaseEntity;

namespace ProjectTemplate.Infrastructure.BaseRepository.Interfaces
{
    public interface IRepository<T> : IBaseRepository<T, int> where T : BaseEntity<int>
    {
        
    }
}