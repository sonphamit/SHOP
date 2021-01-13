using AutoMapper;
using Infrastructure.Mappings;
using Microsoft.Extensions.DependencyInjection;

namespace Store.Configuration
{
    public static class MapperConfiguration
    {
        public static void AddMapperConfiguration(this IServiceCollection services)
        {
            //services.AddAutoMapper(Assembly.GetExecutingAssembly(typeof(Startup)));
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(typeof(MappingProfile));
            //Mapper.Initialize(cfg =>
            //{
            //    cfg.AddProfiles(typeof(IMappingProfile));
            //});
            //services.AddAutoMapper();
        }
    }
}
