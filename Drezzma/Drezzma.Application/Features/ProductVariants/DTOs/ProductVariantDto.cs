namespace Drezzma.Application.Features.ProductVariants.DTOs
{
    public class ProductVariantDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public Guid SizeId { get; set; }

        public Guid ColorId { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string? SKU { get; set; }

        public bool IsActive { get; set; }
    }
}