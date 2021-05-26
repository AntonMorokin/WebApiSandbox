using System;
using System.Collections.Generic;

namespace Core.Model.Domain
{
    public class Car
    {
        public int CarId { get; private set; }

        public string Number { get; set; }

        public string BrandName { get; set; }

        public string ModelName { get; set; }

        public string Color { get; set; }

        public DateTime ManufacturedDate { get; set; }

        public decimal KilometersHaveBeenDriven { get; set; }

        public CarState State { get; set; }

        public string ParkingAddress { get; set; }

        public List<Client> UsedByClients { get; set; }

        public List<Drive> Drives { get; set; }
    }
}
