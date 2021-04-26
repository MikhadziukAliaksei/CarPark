namespace CarPark.Entities.Models
{
    public class CarSpecification
    {
        public int Id { get; set; }
        
        public double EngineVolume { get; set; }

        public int DoorNumber { get; set; }

        public string BodyType { get; set; }

        public int SeatNumber { get; set; }

        public string EngineType { get; set; }

        public int CarId { get; set; }

        public Car Car { get; set; }
    }
}
