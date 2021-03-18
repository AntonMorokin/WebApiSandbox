using Core.Model;
using Core.Model.Geographic;
using Core.Model.Persons;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Core.Database
{
    public sealed class DataContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<CheckPoint> CheckPoints { get; set; }

        public DbSet<Route> Routes { get; set; }

        public DbSet<Trip> Trips { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Client

            modelBuilder.Entity<Client>()
                .HasKey(c => c.PersonId);

            modelBuilder.Entity<Client>()
                .Property(c => c.PersonId)
                .HasColumnName(nameof(Client) + "Id");

            modelBuilder.Entity<Client>()
                .Property(c => c.PersonId)
                // Just for annotating.
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Client>()
                .Property(c => c.FirstName)
                .IsRequired();

            modelBuilder.Entity<Client>()
                .Property(c => c.LastName)
                .IsRequired();

            #endregion

            #region Employee

            modelBuilder.Entity<Employee>()
                .HasKey(e => e.PersonId);

            modelBuilder.Entity<Employee>()
                .Property(e => e.PersonId)
                .HasColumnName(nameof(Employee) + "Id");

            modelBuilder.Entity<Employee>()
                .Property(e => e.PersonId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Employee>()
                .Property(e => e.FirstName)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.LastName)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(e => e.Position)
                .IsRequired();

            #endregion

            #region RoutePoint

            modelBuilder.Entity<RoutePoint>()
                .HasKey(p => p.PointId);

            modelBuilder.Entity<RoutePoint>()
                .Property(p => p.PointId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<RoutePoint>()
                .Property(p => p.LatitudeType)
                .HasConversion<string>();

            modelBuilder.Entity<RoutePoint>()
                .Property(p => p.LongitudeType)
                .HasConversion<string>();

            #endregion

            #region CheckPoint

            modelBuilder.Entity<CheckPoint>()
                .HasKey(p => p.PointId);

            modelBuilder.Entity<CheckPoint>()
                .Property(p => p.PointId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<CheckPoint>()
                .Property(p => p.Name)
                .IsRequired();

            modelBuilder.Entity<CheckPoint>()
                .Property(p => p.LatitudeType)
                .HasConversion<string>();

            modelBuilder.Entity<CheckPoint>()
                .Property(p => p.LongitudeType)
                .HasConversion<string>();

            #endregion

            #region Route

            modelBuilder.Entity<Route>()
                .HasKey(r => r.RouteId);

            modelBuilder.Entity<Route>()
                .Property(r => r.RouteId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Route>()
                .Property(r => r.Name)
                .IsRequired();

            #endregion

            #region Trip

            modelBuilder.Entity<Trip>()
                .HasKey(t => t.TripId);

            modelBuilder.Entity<Trip>()
                .Property(t => t.TripId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Trip>()
                .Property(t => t.Status)
                .HasConversion<string>();

            #endregion

            #region Relations

            modelBuilder.Entity<Client>()
                .HasMany(c => c.Trips)
                .WithMany(t => t.Participants)
                .UsingEntity<Dictionary<string, object>>(
                    "ClientsToTrips",
                    e => e.HasOne<Trip>()
                        .WithMany()
                        .HasForeignKey(nameof(Trip.TripId)),
                    e => e.HasOne<Client>()
                        .WithMany()
                        .HasForeignKey(nameof(Client) + "Id")
                );

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Trips)
                .WithMany(t => t.Guides)
                .UsingEntity<Dictionary<string, object>>(
                    "EmployeesToTrips",
                    e => e.HasOne<Trip>()
                        .WithMany()
                        .HasForeignKey(nameof(Trip.TripId)),
                    e => e.HasOne<Employee>()
                        .WithMany()
                        .HasForeignKey(nameof(Employee) + "Id")
                );

            modelBuilder.Entity<RoutePoint>()
                .HasOne(p => p.Route)
                .WithMany(r => r.SimplePoints)
                .HasForeignKey(r => r.RouteId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CheckPoint>()
                .HasMany(p => p.Routes)
                .WithMany(r => r.CheckPoints)
                .UsingEntity<CheckPointToRouteMapping>(
                    e => e
                        .HasOne(m => m.Route)
                        .WithMany(r => r.CheckPointsMapping)
                        .HasForeignKey(m => m.RouteId)
                        .OnDelete(DeleteBehavior.Cascade),
                    e => e
                        .HasOne(m => m.Point)
                        .WithMany(p => p.RoutesMapping)
                        .HasForeignKey(m => m.CheckPointId)
                        .OnDelete(DeleteBehavior.Cascade),
                    e =>
                    {
                        e.HasKey(m => new { m.RouteId, m.CheckPointId });
                    });

            modelBuilder.Entity<Trip>()
                .HasOne(t => t.Route)
                .WithMany(r => r.Trips)
                .HasForeignKey(t => t.TripId);

            #endregion
        }
    }
}
