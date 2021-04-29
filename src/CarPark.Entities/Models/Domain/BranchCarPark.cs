using System.Collections.Generic;
using CarPark.Entities.Models;

namespace CarPark.Entities.Models
{
    public class BranchCarPark
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }
        
        public ICollection<Order> Orders { get; set; }
    }
}
