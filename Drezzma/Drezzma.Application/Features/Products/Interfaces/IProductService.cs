using Drezzma.Application.Features.Products.DTOs;

namespace Drezzma.Application.Features.Products.Interfaces
{
    public interface IProductService
    {
        Task<ProductResponse> CreateAsync(CreateProductRequest request);
        Task<ProductResponse> GetByIdAsync(Guid id);
        Task<ProductResponse> GetBySlugAsync(string slug);
        Task<IReadOnlyList<ProductResponse>> GetAllAsync();
        Task<ProductResponse> UpdateAsync(Guid id, UpdateProductRequest request);
        Task<ProductDetailDto> GetDetailsBySlugAsync(string slug);
        Task DeleteAsync(Guid id);
    }
}
