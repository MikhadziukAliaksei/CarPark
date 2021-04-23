using CarPark.Contracts.Interfaces;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Bll.Services
{
    public class CarSpecificationsService : ICarSpecificationService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CarSpecificationsService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void CreateSpecificationForCar(CarSpecification carSpec, int carId)
        {
            _repositoryManager.CarSpecification.CreateSpecification(carSpec, carId);
            _repositoryManager.Save();
        }

        public CarSpecification GetCarSpecification(int carId, int id, bool trackChanges)
        {
            return _repositoryManager.CarSpecification.GetCarSpecification(carId, id, trackChanges);
        }

        public IEnumerable<CarSpecification> GetCarsSpecifications(bool trackChanges)
        {
            throw new System.NotImplementedException();
        }
    }
}
