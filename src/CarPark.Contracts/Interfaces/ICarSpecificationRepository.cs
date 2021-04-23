using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Contracts.Interfaces
{
    public interface ICarSpecificationRepository
    {
        IEnumerable<CarSpecification> GetSpecifications(bool trackChanges);

        CarSpecification GetCarSpecification(int carId, int id, bool trackChanges);

        void CreateSpecification(CarSpecification carSpec, int carId);
    }
}
