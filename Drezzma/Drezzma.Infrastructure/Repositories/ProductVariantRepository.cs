using Drezzma.Application.Interfaces;
using Drezzma.Domain.Entities;
using Drezzma.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Drezzma.Infrastructure.Repositories
{
    public class ProductVariantRepository:GenericRepository<ProductVariant>, IProductVariantRepository
    {
        private readonly DrezzmaDbContext _context;

        public ProductVariantRepository(DrezzmaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ProductVariant>> GetByProductIdAsync(Guid productId)
        {
            return await _context.ProductVariants
                .Where(x => x.ProductId == productId)
                .AsNoTracking()
                .ToListAsync();
        }
        //public async Task<ProductVariant?> GetByIdAsync(Guid id)
        //{
        //    return await _context.ProductVariants
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //}

        //public async Task AddAsync(ProductVariant variant)
        //{
        //    await _context.ProductVariants.AddAsync(variant);
        //}

        //public void Update(ProductVariant variant)
        //{
        //    _context.ProductVariants.Update(variant);
        //}

        //public void Delete(ProductVariant variant)
        //{
        //    _context.ProductVariants.Remove(variant);
        //}
    }
}
