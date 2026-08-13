using Drezzma.Domain.Entities;

namespace Drezzma.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        Task<Product?> GetBySlugAsync(string slug);

    }
}
