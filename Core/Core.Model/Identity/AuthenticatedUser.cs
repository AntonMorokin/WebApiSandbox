namespace Core.Model.Identity
{
    public sealed class AuthenticatedUser
    {
        public string UserName { get; set; }

        public string DisplayName { get; set; }

        public string Email { get; set; }

        public string AccessToken { get; set; }
    }
}
