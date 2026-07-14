using Drezzma.Domain.Common;

namespace Drezzma.Domain.Entities
{
    public class Color : BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;

        public string? HexCode { get; set; }

        public bool IsActive { get; set; } = true;

        public ICollection<ProductVariant> ProductVariants { get; set; } = new List<ProductVariant>();
    }
}
