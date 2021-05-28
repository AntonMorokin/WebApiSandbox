using Core.Common;
using Core.Model.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Core.Logic.Identity
{
    public sealed class JwtBearerHandlerWithIdentity : JwtBearerHandler
    {
        private UserManager<IdentifiedUser> _userManager;

        public JwtBearerHandlerWithIdentity(IOptionsMonitor<JwtBearerOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            UserManager<IdentifiedUser> userManager)
            : base(options, logger, encoder, clock)
        {
            _userManager = userManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            var result = await base.HandleAuthenticateAsync();
            
            if (result.Succeeded && result.Principal != null)
            {
                var principal = result.Principal;
                var claimsLoadingResult = await LoadClaims(principal);
                if (claimsLoadingResult.Success && claimsLoadingResult.Result != null)
                {
                    var mainIdentity = principal.Identities.First();
                    mainIdentity.AddClaims(claimsLoadingResult.Result);
                }
            }

            return result;
        }

        private async Task<SimpleResult<IList<Claim>>> LoadClaims(ClaimsPrincipal principal)
        {
            var identityId = principal.FindFirstValue(JwtRegisteredClaimNames.NameId);
            if (string.IsNullOrEmpty(identityId))
            {
                return new SimpleResult<IList<Claim>>
                {
                    Success = false
                };
            }

            var user = await _userManager.FindByIdAsync(identityId);
            if (user == null)
            {
                return new SimpleResult<IList<Claim>>
                {
                    Success = false
                };
            }

            var claims = await _userManager.GetClaimsAsync(user);
            if (claims != null && claims.Count > 0)
            {
                return new SimpleResult<IList<Claim>>
                {
                    Success = true,
                    Result = claims
                };
            }

            return new SimpleResult<IList<Claim>>
            {
                Success = false
            };
        }
    }
}
