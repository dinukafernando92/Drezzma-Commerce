using Drezzma.Domain.Enums;

namespace Drezzma.Application.Features.Products.DTOs
{
    public class ProductResponse
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ProductType ProductType { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
        public string Slug { get; set; } = string.Empty;
    }
}
