using Core.Model.Geographic;
using Core.Model.Persons;
using System;
using System.Collections.Generic;

namespace Core.Model
{
    public class Trip
    {
        public int TripId { get; private set; }

        public int RouteId { get; set; }

        public Route Route { get; set; }

        public List<Employee> Guides { get; set; }

        public List<Client> Participants { get; set; }

        public RoutePoint LastPassedPoint { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime? FinishTime { get; set; }

        public TripStatus Status { get; set; }
    }
}
