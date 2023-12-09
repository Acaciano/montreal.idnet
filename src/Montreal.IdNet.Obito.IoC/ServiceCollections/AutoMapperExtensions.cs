using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Montreal.IdNet.Obito.Application.Mappings.Config;

namespace Montreal.IdNet.Obito.IoC.ServiceCollections
{
    public static class AutoMapperExtensions
    {
        public static void AddMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAutoMapper();

            MappingsConfig.RegisterMappings();
        }
    }
}
