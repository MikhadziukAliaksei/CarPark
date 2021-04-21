using System.Collections.Generic;

namespace CarPark.Entities.Models
{
    public class CarPark
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}
