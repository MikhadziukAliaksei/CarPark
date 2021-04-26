using CarPark.Contracts.Interfaces;
using CarPark.Entities.Context;

namespace CarPark.Repository.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private ApplicationContext _applicationContext;
        private ICarRepository _carRepository;
        private ICarSpecificationRepository _specificationRepository;
        private IManufacturerRepository _manufacturerRepository;

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

        public ICarSpecificationRepository CarSpecification
        {
            get
            {
                return _specificationRepository ??
                    (_specificationRepository = new CarSpecificationRepository(_applicationContext));
            }
        }

        public IManufacturerRepository Manufacturer
        {
            get
            {
                return _manufacturerRepository ??
                    (_manufacturerRepository = new ManufacturerRepository(_applicationContext));
            }
        }

        public void Save() => _applicationContext.SaveChanges();
    }
}
