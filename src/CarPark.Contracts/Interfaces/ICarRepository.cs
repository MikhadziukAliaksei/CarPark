using CarPark.Entities.Models;
using CarPark.Entities.RequestFeatures;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarPark.Contracts.Interfaces
{
    public interface ICarRepository
    {
        Task<PagedList<Car>> GetCarsAsync(CarsParameter carsParameters, bool trackChanges);

        Car GetCar(int id, bool trackChanges);

        void CreateCar(Car car);

        void DeleteCar(int id, bool trackChanges);

        void UpdateCar(Car car);
    }
}
