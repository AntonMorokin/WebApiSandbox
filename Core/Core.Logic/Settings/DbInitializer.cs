using Core.Database.Identity;
using Core.Model.Identity;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Security.Claims;
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

        public async Task CreateUsersAsync()
        {
            _dataContext.Users.RemoveRange(_dataContext.Users);
            // We have to wait for fully rows removing.
            _dataContext.SaveChanges();

            var manager = new IdentifiedUser
            {
                DisplayName = "Oleg the Manager",
                UserName = "Manager",
                Email = "manager@myapp.com"
            };

            var user = new IdentifiedUser
            {
                DisplayName = "Alyosha the User",
                UserName = "User",
                Email = "user@myapp.com"
            };

            await _userManager.CreateAsync(manager, "Qw1234!");
            await _userManager.CreateAsync(user, "Abc321*");
        }

        public async Task AddClaimsAsync()
        {
            var manager = await _userManager.FindByEmailAsync("manager@myapp.com");
            if (manager == null)
            {
                return;
            }

            var claims = await _userManager.GetClaimsAsync(manager);
            await _userManager.RemoveClaimsAsync(manager, claims);

            var managerClaim = new Claim("IsManager", bool.TrueString);

            await _userManager.AddClaimAsync(manager, managerClaim);
        }
    }
}
