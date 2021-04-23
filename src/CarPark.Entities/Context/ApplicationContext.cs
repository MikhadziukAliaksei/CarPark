using CarPark.Entities.Configuration;
using CarPark.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace CarPark.Entities.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Car> Cars { get; set; }

        public DbSet<CarPark.Entities.Models.CarPark> CarParks { get; set; }

        public DbSet<CarSpecification> CarSpecifications { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<ManufacturerCountry> ManufacturerCountries { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new ManufacturerCountryConfiguration());
            builder.ApplyConfiguration(new CarSpecificationConfiguration());
            builder.ApplyConfiguration(new CarConfiguration());

            builder.Entity<Car>()
                .HasOne<CarSpecification>(item => item.CarSpecification)
                .WithOne(item => item.Car)
                .HasForeignKey<CarSpecification>(item => item.CarId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();

        }
    }

}
