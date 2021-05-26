using Core.Logic.Settings;
using Interoperation.Controllers.Cars;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interoperation.Controllers.Public
{
    [ApiController]
    [Route(ControllerScopes.MANAGEMENT + ControllerNames.SETTINGS)]
    public sealed class PublicSettingsController : ControllerBase
    {
        [HttpGet("initialize")]
        public async Task<IActionResult> InitializeAsync([FromServices] IDbInitializer dbInitializer)
        {
            try
            {
                await dbInitializer.InitializeAsync();
                return Ok();
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
