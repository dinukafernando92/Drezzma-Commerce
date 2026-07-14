using Drezzma.Domain.Common;
using System.Drawing;

namespace Drezzma.Domain.Entities
{
    public class ProductVariant: BaseAuditableEntity
    {
        public Guid ProductId { get; set; }

        public Guid SizeId { get; set; }

        public Guid ColorId { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public string? SKU { get; set; }

        public bool IsActive { get; set; } = true;

        public Product Product { get; set; } = null!;

        public Size Size { get; set; } = null!;

        public Color Color { get; set; } = null!;
    }
}
