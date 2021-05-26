using Core.Model.Identity;
using Helpers.Checkers;
using Interoperation.Model.DTO.Public;

namespace Interoperation.Converters.DTO.Public
{
    internal sealed class PublicAuthenticatedUserConverter : IConverter<AuthenticatedUser, PublicAuthenticatedUserDto>
    {
        public PublicAuthenticatedUserDto Convert(AuthenticatedUser source)
        {
            ArgumentChecker.ThrowIfNull(source, nameof(source));

            return new PublicAuthenticatedUserDto
            {
                UserName = source.UserName,
                DisplayName = source.DisplayName,
                Email = source.Email,
                AccessToken = source.AccessToken
            };
        }
    }
}
