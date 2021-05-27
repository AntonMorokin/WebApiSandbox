using Core.Logic.Identity;
using Core.Model.Identity;
using Interoperation.Controllers.Cars;
using Interoperation.Converters.DTO;
using Interoperation.Model.DTO.Public;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Threading.Tasks;

namespace Interoperation.Controllers.Public
{
    [ApiController]
    [Route(ControllerScopes.PUBLIC + ControllerNames.IDENTITY)]
    [AllowAnonymous]
    public sealed class PublicIdentityContoller : ControllerBase
    {
        private IAuthManager _authManager;
        private IConverter<AuthenticatedUser, PublicAuthenticatedUserDto> _converter;

        public PublicIdentityContoller(IAuthManager authManager,
            IConverter<AuthenticatedUser, PublicAuthenticatedUserDto> converter)
        {
            _authManager = authManager;
            _converter = converter;
        }

        [HttpGet("getToken")]
        public async Task<ActionResult<PublicAuthenticatedUserDto>> GetToken(
            [FromQuery, Required, EmailAddress] string email,
            [FromQuery, Required, MaxLength(128)] string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var authResult = await _authManager.AuthenticateUserAsync(email, password);
            if (authResult.Success)
            {
                return _converter.Convert(authResult.Result);
            }

            return new StatusCodeResult((int)HttpStatusCode.Unauthorized);
        }
    }
}
