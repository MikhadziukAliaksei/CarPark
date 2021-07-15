using CarPark.Entities.Models;
using CarPark.Entities.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarPark.Contracts.Services
{
    public interface ICarService
    {
        Task<PagedList<Car>> GetCarsAsync(CarsParameter carsParameters, bool trackChanges);

        Car GetCar(int id, bool trackChanges);

        void CreateCar(Car car);

        void DeleteCar(Car car, bool trackChanges);

        void UpdateCar();
    }
}
