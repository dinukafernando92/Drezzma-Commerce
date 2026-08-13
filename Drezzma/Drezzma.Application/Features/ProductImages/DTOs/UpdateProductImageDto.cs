namespace Drezzma.Application.Features.ProductImages.DTOs
{
    public class UpdateProductImageDto
    {
        public string ImageUrl { get; set; } = string.Empty;

        public bool IsPrimary { get; set; }

        public int DisplayOrder { get; set; }
    }
}