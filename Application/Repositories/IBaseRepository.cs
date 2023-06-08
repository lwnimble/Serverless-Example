using Domain.Common;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(T entity);
        Task<T> Get(string id, string partitionKey, CancellationToken cancellationToken);
        Task<List<T>> GetAll(CancellationToken cancellationToken);
    }
}
