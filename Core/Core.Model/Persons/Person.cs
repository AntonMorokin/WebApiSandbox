using System;
using System.Collections.Generic;

namespace Core.Model.Persons
{
    public class Person
    {
        public int PersonId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public List<Trip> Trips { get; set; }
    }
}
