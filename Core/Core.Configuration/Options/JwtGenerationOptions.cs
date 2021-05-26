using System.ComponentModel.DataAnnotations;

namespace Core.Configuration.Options
{
    public sealed class JwtGenerationOptions
    {
        public const string SECTION_NAME = "Jwt";

        [Required, StringLength(32, MinimumLength = 32)]
        public string SecretKey { get; init; }
    }
}
