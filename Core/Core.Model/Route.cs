using Core.Model.Geographic;
using System.Collections.Generic;

namespace Core.Model
{
    public class Route
    {
        public int RouteId { get; private set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal LengthInKilometers { get; set; }

        public decimal ExpectedDurationInDays { get; set; }

        public List<RoutePoint> SimplePoints { get; set; }

        public List<CheckPoint> CheckPoints { get; set; }

        public List<CheckPointToRouteMapping> CheckPointsMapping { get; set; }

        public List<Trip> Trips { get; set; }
    }
}
