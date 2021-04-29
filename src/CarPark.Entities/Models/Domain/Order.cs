using System;

namespace CarPark.Entities.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CarParkId { get; set; }

        public BranchCarPark CarPark { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }

        public int CarId { get; set; }

        public Car Car  { get; set; }

        public bool IsDeleted { get; set; }
    }
}
