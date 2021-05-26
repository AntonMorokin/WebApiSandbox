namespace Interoperation.Model.DTO.Public
{
    public sealed class PublicAuthenticatedUserDto
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string AccessToken { get; set; }
    }
}
