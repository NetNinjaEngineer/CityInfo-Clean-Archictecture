using CityInfo.Domain;
using Microsoft.EntityFrameworkCore;

namespace CityInfo.Persistence;
public class CityInfoDbContext : DbContext
{
    public CityInfoDbContext()
    {

    }

    public CityInfoDbContext(DbContextOptions<CityInfoDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CityInfoDbContext).Assembly);

    }

    public DbSet<City> Cities { get; set; }

    public DbSet<PointOfInterest> PointsOfInterest { get; set; }

}
