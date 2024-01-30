using CityInfo.Application.DTOs.Common;

namespace CityInfo.Application.DTOs
{
    public class PointOfInterestDto : BaseDto
    {
        public string? Category { get; set; }

        public string? Description { get; set; }

        public CityDto City { get; set; }

        public int CityId { get; set; }
    }
}
