using Core.Logic.Cars;
using Core.Model;
using Interoperation.Converters.DTO;
using Interoperation.Model.DTO.Cars;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Interoperation.Controllers.Cars
{
    [ApiController]
    [Route("[controller]")]
    public sealed class CarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IConverter<Car, CarDto> _converter;

        public CarsController(ICarService carService, IConverter<Car, CarDto> converter)
        {
            _carService = carService;
            _converter = converter;
        }

        [HttpGet]
        [Route("available")]
        public IEnumerable<CarDto> GetAvailableCars()
        {
            return _carService
                .GetAvailableCars()
                .Select(_converter.Convert);
        }
    }
}
