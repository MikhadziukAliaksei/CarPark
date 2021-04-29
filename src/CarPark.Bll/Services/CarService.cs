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

        public void CreateCar(Car car)
        {
            _repositoryManager.Car.CreateCar(car);
            _repositoryManager.Save();
        }

        public void DeleteCar(Car car, bool trackChanges)
        {
            _repositoryManager.Car.DeleteCar(car.Id, trackChanges);
        }

        public Car GetCar(int id, bool trackChanges)
        {
            return _repositoryManager.Car.GetCar(id, trackChanges);
        }

        public IEnumerable<Car> GetCars(bool trackChanges)
        {
            var cars = _repositoryManager.Car.GetCars(trackChanges);
            return cars;
        }

        public void UpdateCar()
        {
            _repositoryManager.Save();
        }
    }
}