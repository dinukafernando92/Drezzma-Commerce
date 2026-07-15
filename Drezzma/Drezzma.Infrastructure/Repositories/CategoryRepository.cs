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

        //public async Task<IReadOnlyList<Category>> GetAllAsync()
        //{
        //    return await _context.Categories
        //        .AsNoTracking()
        //        .ToListAsync();
        //}

        //public async Task<Category?> GetByIdAsync(Guid id)
        //{
        //    return await _context.Categories
        //        .FirstOrDefaultAsync(x => x.Id == id);
        //}

        public async Task<Category?> GetBySlugAsync(string slug)
        {
            return await _context.Categories
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Slug == slug);
        }

        //public async Task AddAsync(Category category)
        //{
        //    await _context.Categories.AddAsync(category);
        //}

        //public void Update(Category category)
        //{
        //    _context.Categories.Update(category);
        //}

        //public void Delete(Category category)
        //{
        //    _context.Categories.Remove(category);
        //}
    }
}
