using System;

namespace CarPark.EntitiesDto.Order
{
    public class OrderForUpdateDto
    {
        public DateTime OrderDate { get; set; }

        public int CarParkId { get; set; }

        public int ClientId { get; set; }

        public int CarId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
