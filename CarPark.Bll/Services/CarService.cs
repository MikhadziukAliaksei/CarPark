using CarPark.Contracts.Interfaces;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Bll.Services
{
    public class CarService : ICarService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CarService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public IEnumerable<Car> GetCars(bool trackChanges)
        {
            var cars = _repositoryManager.Car.GetCars(trackChanges);
            return cars;
        }
    }
}
