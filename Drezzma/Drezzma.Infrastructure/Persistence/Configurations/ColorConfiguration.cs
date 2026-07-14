using Drezzma.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Drezzma.Infrastructure.Persistence.Configurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.HexCode)
                   .HasMaxLength(7);

            builder.Property(x => x.IsActive)
                   .HasDefaultValue(true);

            builder.HasIndex(x => x.Name)
                   .IsUnique();

            builder.HasMany(x => x.ProductVariants)
                   .WithOne(x => x.Color)
                   .HasForeignKey(x => x.ColorId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
