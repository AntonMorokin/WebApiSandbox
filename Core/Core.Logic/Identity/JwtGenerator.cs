using Core.Common;
using Core.Configuration.Services;
using Helpers.Checkers;
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
        private IX509CertificateLoader _certificateLoader;

        public JwtGenerator(ITimeManager timeManager, IX509CertificateLoader certificateLoader)
        {
            _timeManager = timeManager;
            _certificateLoader = certificateLoader;
        }

        public string Generate(string userId)
        {
            ArgumentChecker.ThrowIfNullOrEmpty(userId, nameof(userId));

            var claims = new Claim[] { new Claim(JwtRegisteredClaimNames.NameId, userId) };

            var now = _timeManager.LocalDateTime;

            var descriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                IssuedAt = now,
                NotBefore = now,
                Expires = now.Add(__expiryTimeout),
                SigningCredentials = CreateSigningCredentials()
            };

            var token = __tokenHandler.CreateJwtSecurityToken(descriptor);
            return __tokenHandler.WriteToken(token);
        }

        private SigningCredentials CreateSigningCredentials()
        {
            var cert = _certificateLoader.CertificateForJwtProcessing.Value;
            return new X509SigningCredentials(cert);
        }
    }
}
