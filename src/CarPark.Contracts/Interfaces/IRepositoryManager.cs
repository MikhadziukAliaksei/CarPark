namespace CarPark.Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        ICarRepository Car { get; }

        ICarSpecificationRepository CarSpecification { get; }

        IManufacturerRepository Manufacturer { get; }

        IOrderRepository Order { get;}

        ICarParkRepository CarPark { get; }

        void Save();
    }
}
