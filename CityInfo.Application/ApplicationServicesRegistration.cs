using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CityInfo.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddMediatR(options =>
                options.RegisterServicesFromAssemblies(
                    Assembly.GetExecutingAssembly()));

            return services;
        }
    }
}
