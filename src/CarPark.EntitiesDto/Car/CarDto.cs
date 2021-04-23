namespace CarPark.EntitiesDto
{
    public class CarDto
    {
        public int Id { get; set; }

        public string Mark { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public int ManufacturerCountryId { get; set; }

        public int YearOfIssue { get; set; }

        public int CarSpecificationId { get; set; }
    }
}
