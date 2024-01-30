using System.Threading.Tasks;

namespace CityInfo.Application.Contracts.Persistence
{
    public interface IUnitOfWork
    {
        public ICityRepository CityRepository { get; }

        public IPointOfInterestRepository PointOfInterestRepository { get; }

        Task SaveChangesAsync();

    }
}
