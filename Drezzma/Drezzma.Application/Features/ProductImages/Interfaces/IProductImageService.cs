using Drezzma.Application.Features.ProductImages.DTOs;

namespace Drezzma.Application.Features.ProductImages.Interfaces
{
    public interface IProductImageService
    {
        Task<IReadOnlyList<ProductImageDto>> GetByProductIdAsync(
            Guid productId);

        Task<ProductImageDto> GetByIdAsync(Guid id);

        Task<ProductImageDto> CreateAsync(
            CreateProductImageDto dto);

        Task<ProductImageDto> UpdateAsync(
            Guid id,
            UpdateProductImageDto dto);

        Task DeleteAsync(Guid id);
    }
}