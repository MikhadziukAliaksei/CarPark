using CarPark.EntitiesDto.CarSpecification;

namespace CarPark.EntitiesDto.Car
{
    public class CarForUpdate
    {
        public string Mark { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int ManufacturerCountryId { get; set; }

        public int YearOfIssue { get; set; }

        public int CarSpecificationId { get; set; }

        public SpecificationForCarDto CarSpecification { get; set; }

        public bool IsDeleted { get; set; }
    }
}
