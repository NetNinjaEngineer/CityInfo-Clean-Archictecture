using CityInfo.Application.Contracts.Persistence;
using CityInfo.Domain;

namespace CityInfo.Persistence.Repositories;
public class PointOfInterestRepository
    : GenericRepository<PointOfInterest>, IPointOfInterestRepository
{
    public PointOfInterestRepository(CityInfoDbContext context)
        : base(context)
    {
    }
}
