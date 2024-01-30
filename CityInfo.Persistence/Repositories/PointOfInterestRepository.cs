using CityInfo.Application.Persistence.Contracts;
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
