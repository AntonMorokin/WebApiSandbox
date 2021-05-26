using Core.Common;
using Core.Model.Identity;
using System.Threading.Tasks;

namespace Core.Logic.Identity
{
    public interface IAuthManager
    {
        Task<SimpleResult<AuthenticatedUser>> AuthenticateUserAsync(string email, string password);
    }
}