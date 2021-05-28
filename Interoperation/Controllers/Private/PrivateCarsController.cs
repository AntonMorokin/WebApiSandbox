using Core.Logic.Cars;
using Core.Model.Domain;
using Interoperation.Controllers.Cars;
using Interoperation.Converters.DTO;
using Interoperation.Model.DTO.Private;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Interoperation.Controllers.Private
{
    [ApiController]
    [Route(ControllerScopes.PRIVATE + ControllerNames.CARS)]
    public sealed class PrivateCarsController : ControllerBase
    {
        private readonly ICarService _carService;
        private readonly IConverter<Car, PrivateCarDto> _converter;

        public PrivateCarsController(ICarService carService, IConverter<Car, PrivateCarDto> converter)
        {
            _carService = carService;
            _converter = converter;
        }

        [HttpGet("usedByClient/{clientId}")]
        public IEnumerable<PrivateCarDto> GetCarsUsedByClient([FromRoute] int clientId)
        {
            return _carService
                .GetCarsUsedByClientWithDrives(clientId)
                .Select(_converter.Convert)
                .ToList();
        }

        [HttpGet("infoAbout/{carId}")]
        [Authorize(Policy = "IsManager")]
        public IActionResult GetCarInfo([FromRoute] int carId)
        {
            return Ok();
        }
    }
}
