using Core.Configuration.Options;
using Microsoft.Extensions.Options;
using System;

namespace Core.Logic.Identity
{
    internal sealed class JwtGenerator : IJwtGenerator
    {
        private IOptionsSnapshot<JwtGenerationOptions> _settings;

        public JwtGenerator(IOptionsSnapshot<JwtGenerationOptions> jwtGenerationOptions)
        {
            _settings = jwtGenerationOptions;
        }

        public string Generate(string userName)
        {
            throw new NotImplementedException();
        }
    }
}
