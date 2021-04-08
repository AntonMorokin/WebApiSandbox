using Core.Model;
using Helpers.Checkers;
using Interoperation.Model.DTO.Public;

namespace Interoperation.Converters.DTO
{
    internal sealed class PublicCarConverter : IConverter<Car, PublicCarDto>
    {
        public PublicCarDto Convert(Car source)
        {
            ArgumentChecker.ThrowIfNull(source, nameof(source));

            return new PublicCarDto
            {
                Number = source.Number,
                BrandName = source.BrandName,
                ModelName = source.ModelName,
                Color = source.Color,
                ParkingAddress = source.ParkingAddress
            };
        }
    }
}
