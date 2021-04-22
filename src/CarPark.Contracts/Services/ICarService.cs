using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Contracts.Services
{
    public interface ICarService
    {
        IEnumerable<Car> GetCars(bool trackChanges);

        Car GetCar(int id, bool trackChanges);

        void CreateCar(Car car);
    }
}
