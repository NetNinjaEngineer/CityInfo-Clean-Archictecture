using CityInfo.Application.Persistence.Contracts;
using CityInfo.Persistence.Repositories;

namespace CityInfo.Persistence.Managers;
public class UnitOfWork : IUnitOfWork
{
    private readonly CityInfoDbContext _context;
    private readonly ICityRepository _cityRepository;
    private readonly IPointOfInterestRepository _pointOfInterestRepository;

    public UnitOfWork(CityInfoDbContext context)
    {
        _context = context;
        _cityRepository = new CityRepository(_context);
        _pointOfInterestRepository = new PointOfInterestRepository(_context);
    }

    public ICityRepository CityRepository => _cityRepository;

    public IPointOfInterestRepository PointOfInterestRepository => _pointOfInterestRepository;

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();
}
