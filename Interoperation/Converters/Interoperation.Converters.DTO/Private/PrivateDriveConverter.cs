using Core.Model.Domain;
using Interoperation.Model.DTO.Private;

namespace Interoperation.Converters.DTO.Private
{
    internal sealed class PrivateDriveConverter : IConverter<Drive, PrivateDriveDto>
    {
        public PrivateDriveDto Convert(Drive source)
        {
            return new PrivateDriveDto
            {
                DriveId = source.DriveId,
                StartingAddress = source.StartingAddress,
                FinishingAddress = source.FinishingAddress,
                WayLength = source.WayLength,
                StartingDateTime = source.StartingDateTime,
                FinishingDateTime = source.FinishingDateTime
            };
        }
    }
}
