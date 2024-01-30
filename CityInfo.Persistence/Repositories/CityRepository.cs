using CityInfo.Application.Contracts.Persistence;
using CityInfo.Domain;

namespace CityInfo.Persistence.Repositories;

public class CityRepository : GenericRepository<City>, ICityRepository
{
    public CityRepository(CityInfoDbContext context)
        : base(context)
    {
    }
}
