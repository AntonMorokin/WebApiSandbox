using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public sealed class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
    }
}
