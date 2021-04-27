namespace CarPark.Entities.Models.Audit
{
    public class CarAudit
    {
        public int Id { get; set; }

        public int CarId { get; set; }

        public string Operation { get; set; }

        public string CreateAt { get; set; }
    }
}
