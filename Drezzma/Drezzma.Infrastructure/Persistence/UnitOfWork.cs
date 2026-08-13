using Drezzma.Application.Interfaces;
using Drezzma.Infrastructure.Persistence.Context;

namespace Drezzma.Infrastructure.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DrezzmaDbContext _context;

        public ICategoryRepository Categories { get; }
        public IProductRepository Products { get; }
        public IProductVariantRepository ProductVariants { get; }
        public IProductImageRepository ProductImages { get; }

        public UnitOfWork(
            DrezzmaDbContext context,
            ICategoryRepository categoryRepository,
            IProductRepository productRepository,
            IProductVariantRepository productVariantRepository,
            IProductImageRepository productImageRepository)
        {
            _context = context;

            Categories = categoryRepository;
            Products = productRepository;
            ProductVariants = productVariantRepository;
            ProductImages = productImageRepository;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
      }
}
