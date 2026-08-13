using Drezzma.Domain.Entities;

namespace Drezzma.Application.Interfaces
{
    public interface IProductVariantRepository:IGenericRepository<ProductVariant>
    {
        Task<IReadOnlyList<ProductVariant>> GetByProductIdAsync(Guid productId);
    }
}
