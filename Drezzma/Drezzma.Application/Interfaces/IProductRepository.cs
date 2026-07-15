using Drezzma.Domain.Entities;

namespace Drezzma.Application.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        ////Task<List<Product>> GetAllAsync();
        //Task<IReadOnlyList<Product>> GetAllAsync();

        //Task<Product?> GetByIdAsync(Guid id);

        Task<Product?> GetBySlugAsync(string slug);

        //Task AddAsync(Product product);

        //void Update(Product product);

        //void Delete(Product product);
    }
}
