namespace CarPark.Contracts.Interfaces
{
    public interface IRepositoryManager
    {
        ICarRepository Car { get; }
        void Save();
    }
}
