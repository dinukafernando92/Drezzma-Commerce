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
        public string Slug { get; set; } = string.Empty;
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
