using Core.Model;
using Helpers.Checkers;
using Interoperation.Model.DTO.Cars;

namespace Interoperation.Converters.DTO
{
    internal sealed class CarConverter : IConverter<Car, CarDto>
    {
        public CarDto Convert(Car source)
        {
            ArgumentChecker.ThrowIfNull(source, nameof(source));

            return new CarDto
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
