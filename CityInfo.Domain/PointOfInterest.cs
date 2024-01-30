using CityInfo.Domain.Common;

namespace CityInfo.Domain
{
    public class PointOfInterest : BaseEntity
    {
        public string? Category { get; set; }
        public string? Description { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
    }
}
