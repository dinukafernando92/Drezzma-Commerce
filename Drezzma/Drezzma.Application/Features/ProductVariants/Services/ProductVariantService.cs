using Drezzma.Application.Exceptions;
using Drezzma.Application.Features.ProductVariants.DTOs;
using Drezzma.Application.Features.ProductVariants.Interfaces;
using Drezzma.Application.Interfaces;
using Drezzma.Domain.Entities;
using Mapster;

namespace Drezzma.Application.Features.ProductVariants.Services
{
    public class ProductVariantService : IProductVariantService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductVariantService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<ProductVariantDto>> GetByProductIdAsync(
            Guid productId)
        {
            var productExists =
                await _unitOfWork.Products.ExistsAsync(productId);

            if (!productExists)
                throw new NotFoundException(nameof(Product), productId);

            var variants =
                await _unitOfWork.ProductVariants.GetByProductIdAsync(productId);

            return variants.Adapt<IReadOnlyList<ProductVariantDto>>();
        }

        public async Task<ProductVariantDto> GetByIdAsync(Guid id)
        {
            var variant =
                await _unitOfWork.ProductVariants.GetByIdAsync(id);

            if (variant is null)
                throw new NotFoundException(nameof(ProductVariant), id);

            return variant.Adapt<ProductVariantDto>();
        }

        public async Task<ProductVariantDto> CreateAsync(
            CreateProductVariantDto dto)
        {
            var productExists =
                await _unitOfWork.Products.ExistsAsync(dto.ProductId);

            if (!productExists)
                throw new NotFoundException(
                    nameof(Product),
                    dto.ProductId);

            var variant = dto.Adapt<ProductVariant>();

            variant.SKU = string.IsNullOrWhiteSpace(dto.SKU)
                ? null
                : dto.SKU.Trim();

            await _unitOfWork.ProductVariants.AddAsync(variant);

            await _unitOfWork.SaveChangesAsync();

            return variant.Adapt<ProductVariantDto>();
        }

        public async Task<ProductVariantDto> UpdateAsync(
            Guid id,
            UpdateProductVariantDto dto)
        {
            var variant =
                await _unitOfWork.ProductVariants.GetByIdAsync(id);

            if (variant is null)
                throw new NotFoundException(
                    nameof(ProductVariant),
                    id);

            variant.SizeId = dto.SizeId;
            variant.ColorId = dto.ColorId;
            variant.Price = dto.Price;
            variant.StockQuantity = dto.StockQuantity;
            variant.SKU = string.IsNullOrWhiteSpace(dto.SKU)
                ? null
                : dto.SKU.Trim();
            variant.IsActive = dto.IsActive;

            _unitOfWork.ProductVariants.Update(variant);

            await _unitOfWork.SaveChangesAsync();

            return variant.Adapt<ProductVariantDto>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var variant =
                await _unitOfWork.ProductVariants.GetByIdAsync(id);

            if (variant is null)
                throw new NotFoundException(
                    nameof(ProductVariant),
                    id);

            _unitOfWork.ProductVariants.Delete(variant);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}