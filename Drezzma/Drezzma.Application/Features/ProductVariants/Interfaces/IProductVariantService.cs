using Drezzma.Application.Features.ProductVariants.DTOs;

namespace Drezzma.Application.Features.ProductVariants.Interfaces
{
    public interface IProductVariantService
    {
        Task<IReadOnlyList<ProductVariantDto>> GetByProductIdAsync(Guid productId);

        Task<ProductVariantDto> GetByIdAsync(Guid id);

        Task<ProductVariantDto> CreateAsync(CreateProductVariantDto dto);

        Task<ProductVariantDto> UpdateAsync(
            Guid id,
            UpdateProductVariantDto dto);

        Task DeleteAsync(Guid id);
    }
}