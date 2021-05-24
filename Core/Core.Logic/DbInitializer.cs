using Core.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Core.Database
{
    public static class DbInitializer
    {
        public static async Task InitializeAsync(UserManager<IdentifiedUser> userManager)
        {
            var manager = new IdentifiedUser
            {
                UserName = "Manager",
                Email = "manager@myapp.com"
            };

            var user = new IdentifiedUser
            {
                UserName = "User",
                Email = "user@myapp.com"
            };

            await userManager.CreateAsync(manager, "Qw1234!");
            await userManager.CreateAsync(user, "Abc321*");
        }
    }
}
