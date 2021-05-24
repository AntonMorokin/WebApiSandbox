using Core.Database;
using Core.Model;
using Interoperation.Controllers.Cars;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Interoperation.Controllers.Public
{
    [ApiController]
    [Route(ControllerScopes.PUBLIC + "/" + "settings")]
    public sealed class PublicSettingsController : ControllerBase
    {
        private UserManager<IdentifiedUser> _userManager;

        public PublicSettingsController(UserManager<IdentifiedUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet("initialize")]
        public async Task<IActionResult> InitializeAsync()
        {
            try
            {
                await DbInitializer.InitializeAsync(_userManager);
                return Ok();
            }
            catch
            {
                return new StatusCodeResult(500);
            }
        }
    }
}
