using Drezzma.Domain.Common;

namespace Drezzma.Domain.Entities
{
    public class ProductImage: BaseAuditableEntity
    {
        public Guid ProductId { get; set; }

        public string ImageUrl { get; set; } = string.Empty;

        public bool IsPrimary { get; set; }

        public int DisplayOrder { get; set; }

        public Product Product { get; set; } = null!;
    }
}
