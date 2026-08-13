using Drezzma.Application.Features.ProductImages.DTOs;
using Drezzma.Application.Features.ProductVariants.DTOs;
using Drezzma.Domain.Enums;

namespace Drezzma.Application.Features.Products.DTOs
{
    public class ProductDetailDto
    {
        public Guid Id { get; set; }

        public Guid CategoryId { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public ProductType ProductType { get; set; }

        public bool IsFeatured { get; set; }

        public bool IsActive { get; set; }

        public string Slug { get; set; } = string.Empty;

        public IReadOnlyList<ProductImageDto> Images { get; set; }
            = new List<ProductImageDto>();

        public IReadOnlyList<ProductVariantDto> Variants { get; set; }
            = new List<ProductVariantDto>();
    }
}