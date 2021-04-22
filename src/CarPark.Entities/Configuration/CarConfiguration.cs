using CarPark.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPark.Entities.Configuration
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasData(
                new Car
                {
                    Id = 1,
                    Mark = "Audi",
                    Model = "RS7",
                    Color = "White",
                    Price = 57000,
                    Quantity = 2,
                    YearOfIssue = 2016,
                    ManufacturerCountryId = 1,
                    CarSpecificationId = 1
                },
                new Car
                {
                    Id = 2,
                    Mark = "Audi",
                    Model = "A8",
                    Color = "Black",
                    Price = 12000,
                    Quantity = 1,
                    YearOfIssue = 2018,
                    ManufacturerCountryId = 1,
                    CarSpecificationId = 2
                });
        }
    }
}
