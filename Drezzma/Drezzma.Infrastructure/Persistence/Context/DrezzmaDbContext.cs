using Drezzma.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Drezzma.Infrastructure.Persistence.Context
{
    public class DrezzmaDbContext :DbContext
    {
        public DrezzmaDbContext(DbContextOptions<DrezzmaDbContext> options) : base(options)
        {
        }

        //Go through the entire Drezzma.Infrastructure assembly and find every class that
        //implements IEntityTypeConfiguration<T>, then apply it automatically."
        //If we not use this ,Every time we add a new entity, we must remember to register its configuration.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DrezzmaDbContext).Assembly);
        }

        public DbSet<Category> Categories => Set<Category>();

        public DbSet<Product> Products => Set<Product>();

        public DbSet<ProductImage> ProductImages => Set<ProductImage>();

        public DbSet<ProductVariant> ProductVariants => Set<ProductVariant>();

        public DbSet<Size> Sizes => Set<Size>();

        public DbSet<Color> Colors => Set<Color>();
    }
}
