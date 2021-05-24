using Core.Model;
using Microsoft.EntityFrameworkCore;

namespace Core.Database.Domain
{
    public sealed class DataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Car> Cars { get; set; }

        public DbSet<Drive> Drives { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Client

            modelBuilder.Entity<Client>()
                .HasKey(c => c.ClientId);

            modelBuilder.Entity<Client>()
                .Property(c => c.ClientId)
                // Just for annotating.
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Client>()
                .Property(c => c.FirstName)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.LastName)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.PhoneNumber)
                .IsRequired();

            #endregion

            #region Car

            modelBuilder.Entity<Car>()
                .HasKey(c => c.CarId);

            modelBuilder.Entity<Car>()
                .Property(c => c.CarId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Car>()
                .Property(c => c.Number)
                .IsRequired();

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.Number)
                .IsUnique();

            modelBuilder.Entity<Car>()
                .Property(c => c.BrandName)
                .IsRequired();

            modelBuilder.Entity<Car>()
                .Property(c => c.ModelName)
                .IsRequired();

            modelBuilder.Entity<Car>()
                .Property(c => c.State)
                .HasConversion<string>();

            #endregion

            #region Relations

            modelBuilder.Entity<Client>()
                .HasMany(c => c.UsedCars)
                .WithMany(c => c.UsedByClients)
                .UsingEntity<Drive>(
                    e => e
                        .HasOne(d => d.Car)
                        .WithMany(c => c.Drives)
                        .HasForeignKey(d => d.CarId)
                        .OnDelete(DeleteBehavior.Cascade),
                    e => e
                        .HasOne(d => d.Client)
                        .WithMany(c => c.Drives)
                        .HasForeignKey(m => m.ClientId)
                        .OnDelete(DeleteBehavior.Cascade),
                    e =>
                    {
                        e.HasKey(d => d.DriveId);
                        e.Property(d => d.DriveId).ValueGeneratedOnAdd();

                        e.Property(d => d.StartingAddress).IsRequired();
                        e.Property(d => d.FinishingAddress).IsRequired();

                        e.Ignore(d => d.IsInProgress);
                    });

            #endregion
        }
    }
}
