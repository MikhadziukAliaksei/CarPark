using System;
using System.Collections.Generic;

namespace CarPark.Entities.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CarParkId { get; set; }

        public CarPark CarPark { get; set; }

        public Client Client { get; set; }

        public int ClientId { get; set; }

        public int CarId { get; set; }

        public Car Car  { get; set; }
    }
}
