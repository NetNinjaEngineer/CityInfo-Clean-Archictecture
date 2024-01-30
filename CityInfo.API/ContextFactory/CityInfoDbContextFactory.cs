using CityInfo.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CityInfo.API.ContextFactory
{
    public class CityInfoDbContextFactory : IDesignTimeDbContextFactory<CityInfoDbContext>
    {
        public CityInfoDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<CityInfoDbContext>();

            builder.UseSqlServer(configuration.GetConnectionString("CityInfoConnectionString"),
                options => options.MigrationsAssembly("CityInfo.Persistence"));

            return new CityInfoDbContext(builder.Options);

        }
    }
}
