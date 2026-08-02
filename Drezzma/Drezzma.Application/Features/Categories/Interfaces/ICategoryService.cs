using Drezzma.Application.Features.Categories.DTOs;

namespace Drezzma.Application.Features.Categories.Interfaces
{
    public interface ICategoryService
    {
        Task<IReadOnlyList<CategoryDto>> GetAllAsync();

        Task<CategoryDto?> GetByIdAsync(Guid id);

        Task<CategoryDto> CreateAsync(CreateCategoryDto dto);

        Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryDto dto);

        Task DeleteAsync(Guid id);
    }
}
