using Drezzma.Application.Common.Helpers;
using Drezzma.Application.Exceptions;
using Drezzma.Application.Features.ProductImages.DTOs;
using Drezzma.Application.Features.Products.DTOs;
using Drezzma.Application.Features.Products.Interfaces;
using Drezzma.Application.Features.ProductVariants.DTOs;
using Drezzma.Application.Interfaces;
using Drezzma.Domain.Entities;
using Mapster;

namespace Drezzma.Application.Features.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<ProductResponse>> GetAllAsync()
        {
            var products = await _unitOfWork.Products.GetAllAsync();

            return products.Adapt<IReadOnlyList<ProductResponse>>();
        }

        public async Task<ProductResponse> GetByIdAsync(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product is null)
                throw new NotFoundException(nameof(Product), id);

            return product.Adapt<ProductResponse>();
        }

        public async Task<ProductResponse> GetBySlugAsync(string slug)
        {
            var product = await _unitOfWork.Products.GetBySlugAsync(slug);

            if (product is null)
                throw new NotFoundException(nameof(Product), slug);

            return product.Adapt<ProductResponse>();
        }

        public async Task<ProductResponse> CreateAsync(CreateProductRequest dto)
        {
            // Check Category exists
            var categoryExists =
                await _unitOfWork.Categories.ExistsAsync(dto.CategoryId);

            if (!categoryExists)
                throw new NotFoundException(nameof(Category), dto.CategoryId);

            // Generate slug
            var slug = SlugHelper.Generate(dto.Name);

            // Check duplicate product
            var existingProduct =
                await _unitOfWork.Products.GetBySlugAsync(slug);

            if (existingProduct is not null)
                throw new ConflictException(
                    $"Product '{dto.Name}' already exists.");

            // Map DTO to entity
            var product = dto.Adapt<Product>();

            product.Name = dto.Name.Trim();
            product.Slug = SlugHelper.Generate(product.Name);
            product.IsActive = true;

            await _unitOfWork.Products.AddAsync(product);

            await _unitOfWork.SaveChangesAsync();

            return product.Adapt<ProductResponse>();
        }

        public async Task<ProductResponse> UpdateAsync(
            Guid id,
            UpdateProductRequest dto)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product is null)
                throw new NotFoundException(nameof(Product), id);

            // Check Category exists
            var categoryExists =
                await _unitOfWork.Categories.ExistsAsync(dto.CategoryId);

            if (!categoryExists)
                throw new NotFoundException(nameof(Category), dto.CategoryId);

            // Generate new slug
            var slug = SlugHelper.Generate(dto.Name);

            // Check whether another product already uses this slug
            var existingProduct =
                await _unitOfWork.Products.GetBySlugAsync(slug);

            if (existingProduct is not null &&
                existingProduct.Id != id)
            {
                throw new ConflictException(
                    $"Product '{dto.Name}' already exists.");
            }

            product.CategoryId = dto.CategoryId;
            product.Name = dto.Name.Trim();
            product.Description = dto.Description;
            product.ProductType = dto.ProductType;
            product.IsFeatured = dto.IsFeatured;
            product.IsActive = dto.IsActive;
            product.Slug = slug;

            _unitOfWork.Products.Update(product);

            await _unitOfWork.SaveChangesAsync();

            return product.Adapt<ProductResponse>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _unitOfWork.Products.GetByIdAsync(id);

            if (product is null)
                throw new NotFoundException(nameof(Product), id);

            _unitOfWork.Products.Delete(product);

            await _unitOfWork.SaveChangesAsync();
        }
        public async Task<ProductDetailDto> GetDetailsBySlugAsync(string slug)
        {
            var product = await _unitOfWork.Products.GetBySlugAsync(slug);

            if (product is null)
                throw new NotFoundException(nameof(Product), slug);

            var images =
                await _unitOfWork.ProductImages
                    .GetByProductIdAsync(product.Id);

            var variants =
                await _unitOfWork.ProductVariants
                    .GetByProductIdAsync(product.Id);

            return new ProductDetailDto
            {
                Id = product.Id,
                CategoryId = product.CategoryId,
                Name = product.Name,
                Description = product.Description,
                ProductType = product.ProductType,
                IsFeatured = product.IsFeatured,
                IsActive = product.IsActive,
                Slug = product.Slug,

                Images = images.Adapt<IReadOnlyList<ProductImageDto>>(),

                Variants = variants.Adapt<IReadOnlyList<ProductVariantDto>>()
            };
        }

    }
}