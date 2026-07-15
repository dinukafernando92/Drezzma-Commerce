using Drezzma.Application.Features.Categories.DTOs;
using Drezzma.Domain.Entities;
using Mapster;

namespace Drezzma.Application.Mapping
{
    public static class MappingConfig
    {
        public static void RegisterMappings()
        {
            TypeAdapterConfig<Category, CategoryDto>.NewConfig();

            TypeAdapterConfig<CreateCategoryDto, Category>.NewConfig();

            TypeAdapterConfig<UpdateCategoryDto, Category>.NewConfig();
        }
    }
}
