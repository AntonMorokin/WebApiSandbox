using System;

namespace Interoperation.Model.DTO.Private
{
    public sealed class PrivateDriveDto
    {
        public int DriveId { get; set; }

        public DateTime StartingDateTime { get; set; }

        public string StartingAddress { get; set; }

        public DateTime? FinishingDateTime { get; set; }

        public string FinishingAddress { get; set; }

        public decimal WayLength { get; set; }
    }
}
