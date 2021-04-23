using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Contracts.Services
{
    public interface ICarSpecificationService
    {
        IEnumerable<CarSpecification> GetCarsSpecifications(bool trackChanges);

        CarSpecification GetCarSpecification(int carId, int id, bool trackChanges);

        void CreateSpecificationForCar(CarSpecification carSpec, int carId);
    }
}
