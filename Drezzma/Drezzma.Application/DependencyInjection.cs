using Drezzma.Application.Features.Categories.Interfaces;
using Drezzma.Application.Features.Categories.Services;
using Drezzma.Application.Features.ProductImages.Interfaces;
using Drezzma.Application.Features.ProductImages.Services;
using Drezzma.Application.Features.Products.Interfaces;
using Drezzma.Application.Features.Products.Services;
using Drezzma.Application.Features.ProductVariants.Interfaces;
using Drezzma.Application.Features.ProductVariants.Services;
using Drezzma.Application.Interfaces;
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
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductVariantService, ProductVariantService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            return services;
        }
    }
}
