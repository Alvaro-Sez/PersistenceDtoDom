using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Productora.Data;
using Productora.Data.Repositories;
using Productora.Services;
using System;

namespace Productora.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddDbContextPool<ProductoraDbContext>((provider, builder) =>
            {
                builder.UseQueryTrackingBehavior(QueryTrackingBehavior.TrackAll);
                //builder.UseInMemoryDatabase("FabrikTestDatabase");
                builder.UseSqlServer(configuration.GetConnectionString("Productora"));
            });

            services.AddTransient<IProductoraRepository, ProductoraRepository>();
            services.AddTransient<IPeliculaRepository, PeliculaRepository>();
            services.AddTransient<IDirectorRepository, DirectorRepository>();
            services.AddTransient<IActorRepository, ActorRepository>();
            services.AddTransient<IBulkDataService, BulkDataService>();

            return services;
        }
    }
}