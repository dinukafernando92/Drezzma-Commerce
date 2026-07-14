using Drezzma.Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drezzma.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
        {
            // Register your infrastructure services here
            // For example, if you have a DbContext, you can register it like this:
            // services.AddDbContext<DrezzmaDbContext>(options =>
            //     options.UseSqlServer("YourConnectionString"));

            var connectionstring=configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DrezzmaDbContext>(options =>
                options.UseMySql(connectionstring, ServerVersion.AutoDetect(connectionstring)));

            return services;
        }
    }
}
