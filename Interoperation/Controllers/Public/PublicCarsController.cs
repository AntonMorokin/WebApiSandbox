using Core.Logic.Cars;
using Core.Model;
using Interoperation.Converters.DTO;
using Interoperation.Model.DTO.Public;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Interoperation.Controllers.Cars.Public
{
    [ApiController]
    [Route(ControllerScopes.PUBLIC + ControllerNames.CARS)]
    public sealed class PublicCarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IConverter<Car, PublicCarDto> _converter;

        public PublicCarsController(ICarService carService, IConverter<Car, PublicCarDto> converter)
        {
            _carService = carService;
            _converter = converter;
        }

        [HttpGet]
        public IEnumerable<PublicCarDto> GetAvailableCars()
        {
            return _carService
                .GetAvailableCars()
                .Select(_converter.Convert);
        }
    }
}
