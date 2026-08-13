using Drezzma.Application.Exceptions;
using Drezzma.Application.Features.ProductImages.DTOs;
using Drezzma.Application.Features.ProductImages.Interfaces;
using Drezzma.Application.Interfaces;
using Drezzma.Domain.Entities;
using Mapster;

namespace Drezzma.Application.Features.ProductImages.Services
{
    public class ProductImageService : IProductImageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IReadOnlyList<ProductImageDto>>
            GetByProductIdAsync(Guid productId)
        {
            var productExists =
                await _unitOfWork.Products.ExistsAsync(productId);

            if (!productExists)
                throw new NotFoundException(
                    nameof(Product),
                    productId);

            var images =
                await _unitOfWork.ProductImages
                    .GetByProductIdAsync(productId);

            return images.Adapt<IReadOnlyList<ProductImageDto>>();
        }

        public async Task<ProductImageDto> GetByIdAsync(Guid id)
        {
            var image =
                await _unitOfWork.ProductImages.GetByIdAsync(id);

            if (image is null)
                throw new NotFoundException(
                    nameof(ProductImage),
                    id);

            return image.Adapt<ProductImageDto>();
        }

        public async Task<ProductImageDto> CreateAsync(
            CreateProductImageDto dto)
        {
            var productExists =
                await _unitOfWork.Products.ExistsAsync(dto.ProductId);

            if (!productExists)
                throw new NotFoundException(
                    nameof(Product),
                    dto.ProductId);

            var image = dto.Adapt<ProductImage>();

            image.ImageUrl = dto.ImageUrl.Trim();

            await _unitOfWork.ProductImages.AddAsync(image);

            await _unitOfWork.SaveChangesAsync();

            return image.Adapt<ProductImageDto>();
        }

        public async Task<ProductImageDto> UpdateAsync(
            Guid id,
            UpdateProductImageDto dto)
        {
            var image =
                await _unitOfWork.ProductImages.GetByIdAsync(id);

            if (image is null)
                throw new NotFoundException(
                    nameof(ProductImage),
                    id);

            image.ImageUrl = dto.ImageUrl.Trim();
            image.IsPrimary = dto.IsPrimary;
            image.DisplayOrder = dto.DisplayOrder;

            _unitOfWork.ProductImages.Update(image);

            await _unitOfWork.SaveChangesAsync();

            return image.Adapt<ProductImageDto>();
        }

        public async Task DeleteAsync(Guid id)
        {
            var image =
                await _unitOfWork.ProductImages.GetByIdAsync(id);

            if (image is null)
                throw new NotFoundException(
                    nameof(ProductImage),
                    id);

            _unitOfWork.ProductImages.Delete(image);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}