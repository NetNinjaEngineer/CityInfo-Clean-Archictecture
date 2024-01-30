using CityInfo.Application.RequestFeatures;
using CityInfo.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CityInfo.Application.Persistence.Contracts
{
    public interface IPointOfInterestRepository : IGenericRepository<PointOfInterest>
    {
        Task<IEnumerable<PointOfInterest>> GetAllPointsOfInterestAsync(bool trackChanges);

        Task<IEnumerable<PointOfInterest>> GetPointsOfInterestForCityAsync(int cityId, bool trackChanges);

        Task<PointOfInterest> GetPointOfInterestAsync(int cityId, int pointOfInterestId, bool trackChanges);

        void DeletePointOfInterest(PointOfInterest pointOfInterest);

        void UpdatePointOfInterest(PointOfInterest pointOfInterest);

        void CreatePointOfInterest(PointOfInterest pointOfInterest);

        PagedList<PointOfInterest> GetPointsOfInterest(PointOfInterestRequestParameters pointOfInterestParameters);
    }
}
