using System;
using System.Collections.Generic;

namespace Core.Model
{
    public class Client
    {
        public int ClientId { get; private set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public List<Car> UsedCars { get; set; }

        public List<Drive> Drives { get; set; }
    }
}
