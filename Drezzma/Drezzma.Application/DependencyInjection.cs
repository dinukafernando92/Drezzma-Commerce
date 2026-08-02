using Drezzma.Application.Features.Categories.Interfaces;
using Drezzma.Application.Features.Categories.Services;
using Drezzma.Application.Mapping;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Drezzma.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            MappingConfig.RegisterMappings();

            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }
    }
}
