namespace CityInfo.Application.DTOs.PointOfInterest
{
    public abstract class PointOfInterestForManipulation
    {
        public string? Name { get; set; }

        public string? Category { get; set; }

        public string? Description { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }
    }
}