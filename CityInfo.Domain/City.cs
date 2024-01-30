using CityInfo.Domain.Common;
using System.Collections.Generic;

namespace CityInfo.Domain
{
    public class City : BaseEntity
    {
        public string? Country { get; set; }

        public int Population { get; set; }

        public ICollection<PointOfInterest> PointOfInterests { get; set; }
            = new List<PointOfInterest>();
    }
}
