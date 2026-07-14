using Drezzma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drezzma.Infrastructure.Persistence.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ImageUrl)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(x => x.IsPrimary)
                   .HasDefaultValue(false);

            builder.Property(x => x.DisplayOrder)
                   .HasDefaultValue(0);

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.ProductImages)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
