using CarPark.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarPark.Contracts.Interfaces
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetCars(bool trackChanges);

        Car GetCar(int id, bool trackChanges);

        void CreateCar(Car car);

        void DeleteCar(Car car);

        void UpdateCar(Car car);
    }
}
