using Microsoft.AspNetCore.Identity;

namespace Core.Model.Identity
{
    public class IdentifiedUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
