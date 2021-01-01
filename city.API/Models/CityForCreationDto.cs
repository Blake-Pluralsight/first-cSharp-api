using System;
using System.Collections.Generic;

namespace city.API.Models
{
    public class CityForCreationDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int NumberOfPointsOfInterest
        {
            get
            {
                return PointsOfInterest.Count;
            }
        }
        public List<PointOfInterestDto> PointsOfInterest { get; set; } = new List<PointOfInterestDto>();


    }
}
