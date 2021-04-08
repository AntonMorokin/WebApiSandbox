using Core.Model;
using Interoperation.Model.DTO.Private;
using System.Linq;
using System.Text;

namespace Interoperation.Converters.DTO.Private
{
    internal sealed class PrivateCarConverter : IConverter<Car, PrivateCarDto>
    {
        private readonly IConverter<Drive, PrivateDriveDto> _privateDtoConveter;

        public PrivateCarConverter(IConverter<Drive, PrivateDriveDto> privateDtoConveter)
        {
            _privateDtoConveter = privateDtoConveter;
        }

        public PrivateCarDto Convert(Car source)
        {
            return new PrivateCarDto
            {
                Number = source.Number,
                BrandName = source.BrandName,
                ModelName = source.ModelName,
                Color = source.Color,
                ParkingAddress = source.ParkingAddress,
                Drives = source?.Drives.Select(_privateDtoConveter.Convert).ToList()
            };
        }
    }
}
