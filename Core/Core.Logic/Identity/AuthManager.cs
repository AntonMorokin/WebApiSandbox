using Core.Common;
using Core.Model.Identity;
using Microsoft.AspNetCore.Identity;
using System;
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

        public Task<SimpleResult<AuthenticatedUser>> AuthenticateUserAsync(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
