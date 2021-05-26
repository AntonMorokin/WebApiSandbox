using Core.Model.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Database.Identity
{
    public class IdentityDataContext : IdentityDbContext<IdentifiedUser>
    {
        public IdentityDataContext(DbContextOptions<IdentityDataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Add new property to the model.
            builder.Entity<IdentifiedUser>()
                .Property(u => u.DisplayName);
        }
    }
}
