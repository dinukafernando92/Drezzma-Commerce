using Drezzma.Domain.Common;
using Drezzma.Domain.Enums;

namespace Drezzma.Domain.Entities
{
    public class Product: BaseAuditableEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ProductType ProductType { get; set; }

        //public decimal Price { get; set; }

        //public decimal? DiscountPrice { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; } = true;
        public string Slug { get; set; } = string.Empty;
        public Category Category { get; set; } = null!;
        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
