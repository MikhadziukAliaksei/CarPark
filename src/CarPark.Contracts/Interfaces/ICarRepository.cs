using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Contracts.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars(bool trackChanges);

        Car GetCar(int id, bool trackChanges);

        void CreateCar(Car car);

        void DeleteCar(int id, bool trackChanges);

        void UpdateCar(Car car);
    }
}
