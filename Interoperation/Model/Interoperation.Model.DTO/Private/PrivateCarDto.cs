using System.Collections.Generic;

namespace Interoperation.Model.DTO.Private
{
    public sealed class PrivateCarDto
    {
        public string BrandName { get; set; }

        public string ModelName { get; set; }

        public string Color { get; set; }

        public string Number { get; set; }

        public string ParkingAddress { get; set; }

        public List<PrivateDriveDto> Drives { get; set; }
    }
}
