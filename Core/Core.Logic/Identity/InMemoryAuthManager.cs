using Core.Common;
using Core.Model.Identity;
using System.Threading.Tasks;

namespace Core.Logic.Identity
{
    internal sealed class InMemoryAuthManager : IAuthManager
    {
        private IJwtGenerator _jwtGenerator;

        public InMemoryAuthManager(IJwtGenerator jwtGenerator)
        {
            _jwtGenerator = jwtGenerator;
        }

        public Task<SimpleResult<AuthenticatedUser>> AuthenticateUserAsync(string email, string password)
        {
            var jwt = _jwtGenerator.Generate($"{email}:{password}");

            var user = new AuthenticatedUser
            {
                DisplayName = "Test",
                UserName = "Test name",
                Email = email,
                AccessToken = jwt
            };

            var result = new SimpleResult<AuthenticatedUser>
            {
                Success = true,
                Result = user
            };

            return Task.FromResult(result);
        }
    }
}
