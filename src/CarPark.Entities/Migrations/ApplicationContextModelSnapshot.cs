﻿// <auto-generated />
using System;
using CarPark.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CarPark.Entities.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CarPark.Entities.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarSpecificationId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ManufacturerCountryId")
                        .HasColumnType("int");

                    b.Property<string>("Mark")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("YearOfIssue")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManufacturerCountryId");

                    b.ToTable("Cars");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CarSpecificationId = 1,
                            Color = "White",
                            ManufacturerCountryId = 1,
                            Mark = "Audi",
                            Model = "RS7",
                            Price = 57000m,
                            Quantity = 2,
                            YearOfIssue = 2016
                        },
                        new
                        {
                            Id = 2,
                            CarSpecificationId = 2,
                            Color = "Black",
                            ManufacturerCountryId = 1,
                            Mark = "Audi",
                            Model = "A8",
                            Price = 12000m,
                            Quantity = 1,
                            YearOfIssue = 2018
                        });
                });

            modelBuilder.Entity("CarPark.Entities.Models.CarPark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CarParks");
                });

            modelBuilder.Entity("CarPark.Entities.Models.CarSpecification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BodyType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("DoorNumber")
                        .HasColumnType("int");

                    b.Property<string>("EngineType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("EngineVolume")
                        .HasColumnType("float");

                    b.Property<int>("SeatNumber")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarId")
                        .IsUnique();

                    b.ToTable("CarSpecifications");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BodyType = "Liftback",
                            CarId = 1,
                            DoorNumber = 4,
                            EngineType = "Petrol",
                            EngineVolume = 4.0,
                            SeatNumber = 5
                        });
                });

            modelBuilder.Entity("CarPark.Entities.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FlatNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PassportId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("CarPark.Entities.Models.ManufacturerCountry", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ManufacturerCountries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Germany"
                        });
                });

            modelBuilder.Entity("CarPark.Entities.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarId")
                        .HasColumnType("int");

                    b.Property<int>("CarParkId")
                        .HasColumnType("int");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.HasIndex("CarParkId");

                    b.HasIndex("ClientId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CarPark.Entities.Models.Car", b =>
                {
                    b.HasOne("CarPark.Entities.Models.ManufacturerCountry", "ManyfacturerCountry")
                        .WithMany()
                        .HasForeignKey("ManufacturerCountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ManyfacturerCountry");
                });

            modelBuilder.Entity("CarPark.Entities.Models.CarSpecification", b =>
                {
                    b.HasOne("CarPark.Entities.Models.Car", "Car")
                        .WithOne("CarSpecification")
                        .HasForeignKey("CarPark.Entities.Models.CarSpecification", "CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");
                });

            modelBuilder.Entity("CarPark.Entities.Models.Order", b =>
                {
                    b.HasOne("CarPark.Entities.Models.Car", "Car")
                        .WithMany("Orders")
                        .HasForeignKey("CarId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPark.Entities.Models.CarPark", "CarPark")
                        .WithMany("Orders")
                        .HasForeignKey("CarParkId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarPark.Entities.Models.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Car");

                    b.Navigation("CarPark");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("CarPark.Entities.Models.Car", b =>
                {
                    b.Navigation("CarSpecification");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CarPark.Entities.Models.CarPark", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CarPark.Entities.Models.Client", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
