namespace CarPark.Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        ICarRepository Car { get; }
        ICarSpecificationRepository CarSpecification { get; }
        IManufacturerRepository Manufacturer { get; }
        void Save();
    }
}
