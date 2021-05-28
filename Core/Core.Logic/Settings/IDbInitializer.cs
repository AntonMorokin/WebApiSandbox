using System.Threading.Tasks;

namespace Core.Logic.Settings
{
    public interface IDbInitializer
    {
        Task CreateUsersAsync();

        Task AddClaimsAsync();
    }
}