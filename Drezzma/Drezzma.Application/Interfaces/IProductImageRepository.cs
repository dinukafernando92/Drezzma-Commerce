using Drezzma.Domain.Entities;

namespace Drezzma.Application.Interfaces
{
    public interface IProductImageRepository : IGenericRepository<ProductImage>
    {
        Task<IReadOnlyList<ProductImage>> GetByProductIdAsync(Guid productId);
    }
}