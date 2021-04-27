using System;

namespace CarPark.EntitiesDto.Order
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime OrderDate { get; set; }

        public int CarParkId { get; set; } // set from UI

        public int ClientId { get; set; }

        public int CarId { get; set; } // set from UI

        public bool IsDeleted { get; set; }
    }
}
