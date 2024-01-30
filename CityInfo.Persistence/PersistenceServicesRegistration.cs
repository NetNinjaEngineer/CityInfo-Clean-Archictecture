using CityInfo.Application.Contracts.Persistence;
using CityInfo.Persistence.Managers;
using CityInfo.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CityInfo.Persistence;
public static class PersistenceServicesRegistration
{
    public static IServiceCollection ConfigurePersistenceServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CityInfoDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CityInfoConnectionString")));

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

        services.AddScoped<ICityRepository, CityRepository>();

        services.AddScoped<IPointOfInterestRepository, PointOfInterestRepository>();

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;

    }
}
