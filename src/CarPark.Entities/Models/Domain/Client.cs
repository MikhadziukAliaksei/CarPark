using System.Collections.Generic;

namespace CarPark.Entities.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string PassportId { get; set; }

        public string Address { get; set; }

        public string FlatNumber { get; set; }

        public ICollection<Order>  Orders {get;set;} 
    }
}
