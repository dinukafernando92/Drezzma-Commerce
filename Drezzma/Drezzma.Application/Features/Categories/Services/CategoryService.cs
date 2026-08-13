using Drezzma.Application.Common.Helpers;
using Drezzma.Application.Exceptions;
using Drezzma.Application.Features.Categories.DTOs;
using Drezzma.Application.Features.Categories.Interfaces;
using Drezzma.Application.Interfaces;
using Drezzma.Domain.Entities;
using Mapster;

namespace Drezzma.Application.Features.Categories.Services
{
    public class CategoryService:ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<IReadOnlyList<CategoryDto>> GetAllAsync()
        {
            var categories = await _unitOfWork.Categories.GetAllAsync();

            return categories.Adapt<IReadOnlyList<CategoryDto>>();
        }
        public async Task<CategoryDto?> GetByIdAsync(Guid id)
        {
            var category = await _unitOfWork.Categories.GetTrackedByIdAsync(id);

            if (category is null)
                throw new NotFoundException(nameof(Category), id); ;

            return category?.Adapt<CategoryDto>();
        }
        public async Task<CategoryDto> CreateAsync(CreateCategoryDto dto)
        {
            var existingCategory = await _unitOfWork.Categories.GetByNameAsync(dto.Name);

            if (existingCategory is not null)
                throw new ConflictException($"Category '{dto.Name}' already exists.");

            var category = dto.Adapt<Category>();

            category.Name = dto.Name.Trim();
            category.Slug = SlugHelper.Generate(category.Name);

            await _unitOfWork.Categories.AddAsync(category);

            await _unitOfWork.SaveChangesAsync();

            return category.Adapt<CategoryDto>();
        }
        public async Task<CategoryDto> UpdateAsync(Guid id, UpdateCategoryDto dto)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (category is null)
                throw new NotFoundException(nameof(Category), id);

            category.Name = dto.Name;
            category.Description = dto.Description;
            category.DisplayOrder = dto.DisplayOrder;
            category.IsActive = dto.IsActive;

            await _unitOfWork.SaveChangesAsync();

            return category.Adapt<CategoryDto>();
        }
        public async Task DeleteAsync(Guid id)
        {
            var category = await _unitOfWork.Categories.GetByIdAsync(id);

            if (category is null)
                throw new NotFoundException(nameof(Category), id);

            _unitOfWork.Categories.Delete(category);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
