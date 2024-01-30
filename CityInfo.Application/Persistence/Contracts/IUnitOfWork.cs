using System.Threading.Tasks;

namespace CityInfo.Application.Persistence.Contracts
{
    public interface IUnitOfWork
    {
        public ICityRepository CityRepository { get; }

        public IPointOfInterestRepository PointOfInterestRepository { get; }

        Task SaveChangesAsync();

    }
}
