using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Dashboard.Configuration
{
    public static class MapperConfiguration
    {
        public static void AddMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
