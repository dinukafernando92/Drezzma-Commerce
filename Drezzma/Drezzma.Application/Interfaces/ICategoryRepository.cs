using Drezzma.Domain.Entities;

namespace Drezzma.Application.Interfaces
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        //Task<IReadOnlyList<Category>> GetAllAsync();

        //Task<Category?> GetByIdAsync(Guid id);

        Task<Category?> GetBySlugAsync(string slug);
        Task<Category?> GetByNameAsync(string name);

        //Task AddAsync(Category category);

        //void Update(Category category);

        //void Delete(Category category);
    }
}
