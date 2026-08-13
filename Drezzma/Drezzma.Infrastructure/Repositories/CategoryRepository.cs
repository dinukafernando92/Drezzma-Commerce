using Drezzma.Application.Interfaces;
using Drezzma.Domain.Entities;
using Drezzma.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Drezzma.Infrastructure.Repositories
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        private readonly DrezzmaDbContext _context;

        public CategoryRepository(DrezzmaDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category?> GetBySlugAsync(string slug)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Slug == slug);
        }

        public async Task<Category?> GetByNameAsync(string name)
        {
            return await _dbSet
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Name == name.Trim());
        }

    }
}
