using Drezzma.Domain.Enums;

namespace Drezzma.Application.Features.Products.DTOs
{
    public class CreateProductRequest
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ProductType ProductType { get; set; }
        public bool IsFeatured { get; set; }
    }
}
