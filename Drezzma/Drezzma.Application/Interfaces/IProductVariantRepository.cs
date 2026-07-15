using Drezzma.Domain.Entities;

namespace Drezzma.Application.Interfaces
{
    public interface IProductVariantRepository:IGenericRepository<ProductVariant>
    {
        Task<IReadOnlyList<ProductVariant>> GetByProductIdAsync(Guid productId);

        //Task<ProductVariant?> GetByIdAsync(Guid id);

        //Task AddAsync(ProductVariant variant);

        //void Update(ProductVariant variant);

        //void Delete(ProductVariant variant);
    }
}
