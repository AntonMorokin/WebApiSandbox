using Core.Logic.Settings;
using Interoperation.Controllers.Cars;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Interoperation.Controllers.Management
{
    [ApiController]
    [Route(ControllerScopes.MANAGEMENT + ControllerNames.SETTINGS)]
    public sealed class ManagementSettingsController : ControllerBase
    {
        private IDbInitializer _dbInitializer;

        public ManagementSettingsController(IDbInitializer dbInitializer)
        {
            _dbInitializer = dbInitializer;
        }

        [HttpGet("createUsers")]
        public Task<IActionResult> CreateUsersAsync()
        {
            return SafeExecute(async () => await _dbInitializer.CreateUsersAsync());
        }

        [HttpGet("addClaims")]
        public Task<IActionResult> AddClaimsAsync()
        {
            return SafeExecute(async () => await _dbInitializer.AddClaimsAsync());
        }

        private async Task<IActionResult> SafeExecute(Func<Task> executor)
        {
            try
            {
                await executor();
                return Ok();
            }
            catch
            {

                return new StatusCodeResult((int)HttpStatusCode.InternalServerError);
            }
        }
    }
}
