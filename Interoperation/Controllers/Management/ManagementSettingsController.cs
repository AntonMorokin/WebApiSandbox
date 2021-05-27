using Core.Logic.Settings;
using Interoperation.Controllers.Cars;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace Interoperation.Controllers.Management
{
    [ApiController]
    [Route(ControllerScopes.MANAGEMENT + ControllerNames.SETTINGS)]
    [Authorize]
    public sealed class ManagementSettingsController : ControllerBase
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
                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
