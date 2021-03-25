using System;

namespace Core.Model
{
    public class Drive
    {
        public int DriveId { get; private set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }

        public DateTime StartingDateTime { get; set; }

        public string StartingAddress { get; set; }

        public DateTime? FinishingDateTime { get; set; }

        public string FinishingAddress { get; set; }

        public decimal WayLength { get; set; }

        public bool IsInProgress => !FinishingDateTime.HasValue;
    }
}
