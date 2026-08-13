using Drezzma.Application.Interfaces;
using Drezzma.Domain.Entities;
using Drezzma.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Drezzma.Infrastructure.Repositories
{
    public class ProductImageRepository
        : GenericRepository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(DrezzmaDbContext context)
            : base(context)
        {
        }

        public async Task<IReadOnlyList<ProductImage>> GetByProductIdAsync(Guid productId)
        {
            return await _dbSet
                .Where(x => x.ProductId == productId)
                .OrderBy(x => x.DisplayOrder)
                .AsNoTracking()
                .ToListAsync();
        }
    }
}