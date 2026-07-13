namespace Drezzma.Domain.Common
{
    public abstract class BaseAuditableEntity:BaseEntity
    {
        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
    }
}
