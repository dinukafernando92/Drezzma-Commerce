using Drezzma.Domain.Entities;

namespace Drezzma.Application.Interfaces
{
    public interface ICategoryRepository:IGenericRepository<Category>
    {
        Task<Category?> GetBySlugAsync(string slug);
        Task<Category?> GetByNameAsync(string name);

    }
}
