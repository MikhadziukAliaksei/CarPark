using CarPark.Contracts.Interfaces;
using CarPark.Entities.Context;
using CarPark.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarPark.Repository.Repositories
{
    public class CarSpecificationRepository : RepositoryBase<CarSpecification>, ICarSpecificationRepository
    {
        public CarSpecificationRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
                
        }

        public void CreateSpecification(CarSpecification carSpec, int carId)
        {
            carSpec.CarId = carId;
            Create(carSpec);
        }

        public CarSpecification GetCarSpecification(int carId, int id, bool trackChanges) =>
            FindByConditions(item => item.CarId.Equals(carId) && item.Id.Equals(id),  trackChanges)
            .SingleOrDefault();

        public IEnumerable<CarSpecification> GetSpecifications(bool trackChanges) =>
            GetAll(trackChanges)
            .ToList();
    }
}
