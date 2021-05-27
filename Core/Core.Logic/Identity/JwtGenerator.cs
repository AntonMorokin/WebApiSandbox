using Core.Common;
using Core.Configuration.Options;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Core.Logic.Identity
{
    internal sealed class JwtGenerator : IJwtGenerator
    {
        private static TimeSpan __expiryTimeout = TimeSpan.FromMinutes(5);
        private static JwtSecurityTokenHandler __tokenHandler = new JwtSecurityTokenHandler();

        private ITimeManager _timeManager;
        private IOptionsSnapshot<JwtGenerationOptions> _settings;

        public JwtGenerator(ITimeManager timeManager, IOptionsSnapshot<JwtGenerationOptions> jwtGenerationOptions)
        {
            _timeManager = timeManager;
            _settings = jwtGenerationOptions;
        }

        public string Generate(string userName)
        {
            var claims = new Claim[] { new Claim(JwtRegisteredClaimNames.NameId, userName) };

            var now = _timeManager.LocalDateTime;

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = now,
                NotBefore = now,
                Expires = now.Add(__expiryTimeout),
                SigningCredentials = CreateCredentials()
            };

            var token = __tokenHandler.CreateJwtSecurityToken(descriptor);
            return __tokenHandler.WriteToken(token);
        }

        private SigningCredentials CreateCredentials()
        {
            var securityKey = Convert.FromHexString(_settings.Value.SecretKey);
            var signingKey = new SymmetricSecurityKey(securityKey);
            return new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}
