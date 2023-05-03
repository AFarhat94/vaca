
using Core.Interfaces;
using Infra.Data;
using Infra.Services;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class ApplicationConfiguration
    {
        public static IServiceCollection AddApplicationServices (this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<VacaDbContext>(opts => 
            {
                opts.UseSqlite(config.GetConnectionString("VacaConnectionString"));
            });

            services.AddScoped<IPlaceService, PlaceService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}