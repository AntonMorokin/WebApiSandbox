using Microsoft.AspNetCore.Identity;

namespace Core.Model
{
    public class IdentifiedUser : IdentityUser
    {
        public string DisplayName { get; set; }
    }
}
