namespace Drezzma.Domain.Common
{
    public abstract class BaseAuditableEntity:BaseEntity
    {
        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOnUtc { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
