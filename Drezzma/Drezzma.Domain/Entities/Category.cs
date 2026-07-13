using Drezzma.Domain.Common;

namespace Drezzma.Domain.Entities
{
    public class Category:BaseAuditableEntity
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;
    }
}
