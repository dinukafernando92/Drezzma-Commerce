using Drezzma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drezzma.Infrastructure.Persistence.Configurations
{
    public class ProductVariantConfiguration : IEntityTypeConfiguration<ProductVariant>
    {
        public void Configure(EntityTypeBuilder<ProductVariant> builder)
        {
            builder.ToTable("ProductVariants");
            //builder.ToTable("ProductVariants", table =>
            //{
            //    table.HasCheckConstraint("CK_ProductVariant_Price", "`Price` >= 0");
            //    table.HasCheckConstraint("CK_ProductVariant_Stock", "`StockQuantity` >= 0");
            //});

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Price)
                   .HasPrecision(10, 2)
                   .IsRequired();

            builder.Property(x => x.StockQuantity)
                   .HasDefaultValue(0)
                   .IsRequired();

            builder.Property(x => x.SKU)
                   .HasMaxLength(50);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.HasOne(x => x.Product)
                   .WithMany(x => x.ProductVariants)
                   .HasForeignKey(x => x.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.Size)
                   .WithMany(x => x.ProductVariants)
                   .HasForeignKey(x => x.SizeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Color)
                   .WithMany(x => x.ProductVariants)
                   .HasForeignKey(x => x.ColorId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => new
            {
                x.ProductId,
                x.SizeId,
                x.ColorId
            }).IsUnique();

        }
    }
}
