namespace Drezzma.Application.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRepository Categories { get; }

        IProductRepository Products { get; }

        IProductVariantRepository ProductVariants { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
