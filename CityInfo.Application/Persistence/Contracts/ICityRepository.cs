using CityInfo.Domain;
using System.Collections.Generic;

namespace CityInfo.Application.Persistence.Contracts
{
    public interface ICityRepository : IGenericRepository<City>
    {

        void CreateCityCollection(IEnumerable<City> cityCollection);

        void DeleteCity(City city);

        void UpdateCity(City city);

        void CreateCity(City city);
    }
}
