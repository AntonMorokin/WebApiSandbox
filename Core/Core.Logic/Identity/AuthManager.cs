using Core.Common;
using Core.Model.Identity;
using Helpers.Checkers;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Core.Logic.Identity
{
    internal sealed class AuthManager : IAuthManager
    {
        private UserManager<IdentifiedUser> _userMananger;
        private SignInManager<IdentifiedUser> _signInManager;
        private IJwtGenerator _jwtGenerator;

        public AuthManager(UserManager<IdentifiedUser> userMananger,
            SignInManager<IdentifiedUser> signInManager,
            IJwtGenerator jwtGenerator)
        {
            _userMananger = userMananger;
            _signInManager = signInManager;
            _jwtGenerator = jwtGenerator;
        }

        public async Task<SimpleResult<AuthenticatedUser>> AuthenticateUserAsync(string email, string password)
        {
            ArgumentChecker.ThrowIfNullOrEmpty(email, nameof(email));
            ArgumentChecker.ThrowIfNullOrEmpty(password, nameof(password));

            var user = await _userMananger.FindByEmailAsync(email);
            if (user == null)
            {
                return new SimpleResult<AuthenticatedUser>
                {
                    Success = false,
                    ErrorMessage = "There is no user with such email."
                };
            }

            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, password, false);
            if (signInResult.Succeeded)
            {
                var jwt = _jwtGenerator.Generate(user.Id);
                return new SimpleResult<AuthenticatedUser>
                {
                    Success = true,
                    Result = new AuthenticatedUser
                    {
                        DisplayName = user.DisplayName,
                        UserName = user.UserName,
                        Email = user.Email,
                        AccessToken = jwt
                    }
                };
            }

            return new SimpleResult<AuthenticatedUser>
            {
                Success = false
            };
        }
    }
}
