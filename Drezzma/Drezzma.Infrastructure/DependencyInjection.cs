using Drezzma.Application.Interfaces;
using Drezzma.Infrastructure.Persistence;
using Drezzma.Infrastructure.Persistence.Context;
using Drezzma.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drezzma.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register your infrastructure services here
            // For example, if you have a DbContext, you can register it like this:
            // services.AddDbContext<DrezzmaDbContext>(options =>
            //     options.UseSqlServer("YourConnectionString"));

            var connectionString = configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("DefaultConnection is not configured.");

            services.AddDbContext<DrezzmaDbContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductVariantRepository, ProductVariantRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
