using CityInfo.Application.DTOs.Common;
using System.Collections.Generic;

namespace CityInfo.Application.DTOs
{
    public class CityDto : BaseDto
    {
        public string? Country { get; set; }

        public int Population { get; set; }

        public ICollection<PointOfInterestDto> PointOfInterests { get; set; }
            = new List<PointOfInterestDto>();
    }
}
