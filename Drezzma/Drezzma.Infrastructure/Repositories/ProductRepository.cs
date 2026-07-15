using Drezzma.Application.Interfaces;
using Drezzma.Domain.Entities;
using Drezzma.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Drezzma.Infrastructure.Repositories
{
    public class ProductRepository: GenericRepository<Product>, IProductRepository
    {
        private readonly DrezzmaDbContext _context;

        public ProductRepository(DrezzmaDbContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<IReadOnlyList<Product>> GetAllAsync()
        //{
        //    return await _context.Products
        //        .AsNoTracking()
        //        .ToListAsync();
        //}

        //public async Task<Product?> GetByIdAsync(Guid id)
        //{
        //    return await _context.Products
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //}

        public async Task<Product?> GetBySlugAsync(string slug)
        {
            return await _context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Slug == slug);
        }

        //public async Task AddAsync(Product product)
        //{
        //    await _context.Products.AddAsync(product);
        //}

        //public void Update(Product product)
        //{
        //    _context.Products.Update(product);
        //}

        //public void Delete(Product product)
        //{
        //    _context.Products.Remove(product);
        //}
    }
}
