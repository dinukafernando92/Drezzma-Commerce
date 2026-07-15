using Drezzma.Application.Features.Categories.DTOs;

namespace Drezzma.Application.Features.Categories.Services
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<CategoryDto>> GetAllAsync();

        Task<CategoryDto?> GetByIdAsync(Guid id);

        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);

        Task UpdateAsync(Guid id, UpdateCategoryDto dto);

        Task DeleteAsync(Guid id);
    }
}
