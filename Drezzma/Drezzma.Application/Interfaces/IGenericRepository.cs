using Drezzma.Domain.Common;

namespace Drezzma.Application.Interfaces
{
    public interface IGenericRepository<TEntity>
    where TEntity : BaseEntity
    {
        Task<IReadOnlyList<TEntity>> GetAllAsync();

        Task<TEntity?> GetByIdAsync(Guid id);

        Task AddAsync(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task<bool> ExistsAsync(Guid id);
    }
}
