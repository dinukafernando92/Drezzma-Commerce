using Drezzma.Domain.Common;

namespace Drezzma.Domain.Entities
{
    public class Category:BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
        public string? ImageUrl { get; set; }
        public int DisplayOrder { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
