using System.ComponentModel.DataAnnotations;

namespace Drezzma.Application.Features.ProductVariants.DTOs
{
    public class UpdateProductVariantDto
    {
        public Guid SizeId { get; set; }

        public Guid ColorId { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(0, int.MaxValue)]
        public int StockQuantity { get; set; }

        public string? SKU { get; set; }

        public bool IsActive { get; set; }
    }
}