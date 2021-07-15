using CarPark.Contracts.Interfaces;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using CarPark.Entities.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<PagedList<Car>> GetCarsAsync(CarsParameter carsParameters ,bool trackChanges)
        {
            var cars = await _repositoryManager.Car.GetCarsAsync(carsParameters,trackChanges);
            return cars;
        }

        public void UpdateCar()
        {
            _repositoryManager.Save();
        }
    }
}