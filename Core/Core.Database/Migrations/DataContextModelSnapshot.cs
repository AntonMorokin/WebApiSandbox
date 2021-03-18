﻿// <auto-generated />
using System;
using Core.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Core.Database.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("ClientsToTrips", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("integer");

                    b.Property<int>("TripId")
                        .HasColumnType("integer");

                    b.HasKey("ClientId", "TripId");

                    b.HasIndex("TripId");

                    b.ToTable("ClientsToTrips");
                });

            modelBuilder.Entity("Core.Model.Geographic.CheckPoint", b =>
                {
                    b.Property<int>("PointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<decimal>("Altitude")
                        .HasColumnType("numeric");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric");

                    b.Property<string>("LatitudeType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric");

                    b.Property<string>("LongitudeType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PointId");

                    b.ToTable("CheckPoints");
                });

            modelBuilder.Entity("Core.Model.Geographic.CheckPointToRouteMapping", b =>
                {
                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.Property<int>("CheckPointId")
                        .HasColumnType("integer");

                    b.Property<int>("PositionInRoute")
                        .HasColumnType("integer");

                    b.HasKey("RouteId", "CheckPointId");

                    b.HasIndex("CheckPointId");

                    b.ToTable("CheckPointToRouteMapping");
                });

            modelBuilder.Entity("Core.Model.Geographic.RoutePoint", b =>
                {
                    b.Property<int>("PointId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<decimal>("Altitude")
                        .HasColumnType("numeric");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("numeric");

                    b.Property<string>("LatitudeType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("numeric");

                    b.Property<string>("LongitudeType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PositionInRoute")
                        .HasColumnType("integer");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.HasKey("PointId");

                    b.HasIndex("RouteId");

                    b.ToTable("RoutePoint");
                });

            modelBuilder.Entity("Core.Model.Persons.Client", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("ClientId")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.HasKey("PersonId");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("Core.Model.Persons.Employee", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("EmployeeId")
                        .UseIdentityByDefaultColumn();

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("PersonId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Core.Model.Route", b =>
                {
                    b.Property<int>("RouteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<decimal>("ExpectedDurationInDays")
                        .HasColumnType("numeric");

                    b.Property<decimal>("LengthInKilometers")
                        .HasColumnType("numeric");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("RouteId");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("Core.Model.Trip", b =>
                {
                    b.Property<int>("TripId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    b.Property<DateTime?>("FinishTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("LastPassedPointId")
                        .HasColumnType("integer");

                    b.Property<int>("RouteId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("TripId");

                    b.HasIndex("LastPassedPointId");

                    b.ToTable("Trips");
                });

            modelBuilder.Entity("EmployeesToTrips", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("integer");

                    b.Property<int>("TripId")
                        .HasColumnType("integer");

                    b.HasKey("EmployeeId", "TripId");

                    b.HasIndex("TripId");

                    b.ToTable("EmployeesToTrips");
                });

            modelBuilder.Entity("ClientsToTrips", b =>
                {
                    b.HasOne("Core.Model.Persons.Client", null)
                        .WithMany()
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Trip", null)
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Model.Geographic.CheckPointToRouteMapping", b =>
                {
                    b.HasOne("Core.Model.Geographic.CheckPoint", "Point")
                        .WithMany("RoutesMapping")
                        .HasForeignKey("CheckPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Route", "Route")
                        .WithMany("CheckPointsMapping")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Point");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Core.Model.Geographic.RoutePoint", b =>
                {
                    b.HasOne("Core.Model.Route", "Route")
                        .WithMany("SimplePoints")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Core.Model.Trip", b =>
                {
                    b.HasOne("Core.Model.Geographic.RoutePoint", "LastPassedPoint")
                        .WithMany()
                        .HasForeignKey("LastPassedPointId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Route", "Route")
                        .WithMany("Trips")
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LastPassedPoint");

                    b.Navigation("Route");
                });

            modelBuilder.Entity("EmployeesToTrips", b =>
                {
                    b.HasOne("Core.Model.Persons.Employee", null)
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Model.Trip", null)
                        .WithMany()
                        .HasForeignKey("TripId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Core.Model.Geographic.CheckPoint", b =>
                {
                    b.Navigation("RoutesMapping");
                });

            modelBuilder.Entity("Core.Model.Route", b =>
                {
                    b.Navigation("CheckPointsMapping");

                    b.Navigation("SimplePoints");

                    b.Navigation("Trips");
                });
#pragma warning restore 612, 618
        }
    }
}
