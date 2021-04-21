using CarPark.Contracts.Interfaces;
using CarPark.Entities.Context;

namespace CarPark.Repository.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationContext _applicationContext;
        private ICarRepository _carRepository;

        public RepositoryManager(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public ICarRepository Car
        {
            get
            {
                return _carRepository ??
                    (_carRepository = new CarRepository(_applicationContext));
            }
        }

        public void Save() => _applicationContext.SaveChanges();
    }
}
