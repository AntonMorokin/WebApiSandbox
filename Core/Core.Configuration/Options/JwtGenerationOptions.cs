using System.ComponentModel.DataAnnotations;

namespace Core.Configuration.Options
{
    public sealed class JwtGenerationOptions
    {
        public const string SECTION_NAME = "Jwt";

        [Required, StringLength(64, MinimumLength = 64)]
        public string SecretKey { get; init; }
    }
}
