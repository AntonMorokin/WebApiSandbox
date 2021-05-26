using Core.Database.Identity;
using Core.Model;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Core.Logic.Settings
{
    internal sealed class DbInitializer : IDbInitializer
    {
        private IdentityDataContext _dataContext;
        private UserManager<IdentifiedUser> _userManager;

        public DbInitializer(IdentityDataContext dataContext, UserManager<IdentifiedUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public async Task InitializeAsync()
        {
            _dataContext.Users.RemoveRange(_dataContext.Users);

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

            await _userManager.CreateAsync(manager, "Qw1234!");
            await _userManager.CreateAsync(user, "Abc321*");
        }
    }
}
