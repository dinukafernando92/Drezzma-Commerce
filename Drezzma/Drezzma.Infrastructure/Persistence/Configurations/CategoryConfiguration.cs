using Drezzma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drezzma.Infrastructure.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Description)
                   .HasMaxLength(500);

            builder.Property(x => x.ImageUrl)
                   .HasMaxLength(500);

            builder.Property(x => x.DisplayOrder)
                   .HasDefaultValue(0);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.HasIndex(x => x.Name)
                   .IsUnique();

            builder.HasMany(x => x.Products)
                   .WithOne(x => x.Category)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.Property(c => c.Slug)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.HasIndex(c => c.Slug)
                   .IsUnique();
        }
    }
}
