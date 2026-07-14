using Drezzma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drezzma.Infrastructure.Persistence.Configurations
{
    public class SizeConfiguration : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.ToTable("Sizes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.DisplayOrder)
                   .HasDefaultValue(0);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.HasIndex(x => x.Name)
                   .IsUnique();

            builder.HasMany(x => x.ProductVariants)
                   .WithOne(x => x.Size)
                   .HasForeignKey(x => x.SizeId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
