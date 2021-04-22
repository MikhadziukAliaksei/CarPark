using CarPark.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarPark.Entities.Configuration
{
    public class ManufacturerCountryConfiguration : IEntityTypeConfiguration<ManufacturerCountry>
    {
        public void Configure(EntityTypeBuilder<ManufacturerCountry> builder)
        {
            builder.HasData
                (
                new ManufacturerCountry
                {
                    Id = 1,
                    Name = "Germany"
                }
                );
        }
    }
}
