using ECommerce.Application.Contracts.Persistency;
using ECommercePersistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommercePersistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("ECommerceDbConnectionString");
        services.AddDbContext<ECommerceDbContext>(options =>
            options.UseMySql(
                connectionString, ServerVersion.AutoDetect(connectionString)));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<IProductRepositiry, ProductsRepository>();

        return services;
    }
}
