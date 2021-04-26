using System.Collections.Generic;

namespace CarPark.Entities.Models
{
    public class Car
    {
        public int Id { get; set; }

        public string Mark { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public ManufacturerCountry ManyfacturerCountry { get; set; }

        public int ManufacturerCountryId { get; set; }

        public int YearOfIssue { get; set; }

        public int CarSpecificationId { get; set; }
        
        public CarSpecification CarSpecification { get; set; } 

        public ICollection<Order> Orders { get; set; }

        public bool IsDeleted { get; set; } 
    }
}
