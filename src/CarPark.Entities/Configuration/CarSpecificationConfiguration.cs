using CarPark.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPark.Entities.Configuration
{
    public class CarSpecificationConfiguration : IEntityTypeConfiguration<CarSpecification>
    {
        public void Configure(EntityTypeBuilder<CarSpecification> builder)
        {
            builder.HasData
                (
                new CarSpecification
                {
                    Id = 1,
                    EngineVolume = 4.0,
                    DoorNumber = 4,
                    BodyType = "Liftback",
                    SeatNumber = 5,
                    EngineType = "Petrol",
                    CarId = 1
                }
                );
        }
    }
}
