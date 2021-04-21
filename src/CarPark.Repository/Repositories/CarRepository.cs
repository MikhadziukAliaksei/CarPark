using CarPark.Contracts.Interfaces;
using CarPark.Entities.Context;
using CarPark.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarPark.Repository.Repositories
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
        }

        public IEnumerable<Car> GetCars(bool trackChanges) =>
            GetAll(trackChanges)
            .OrderBy(item => item.Mark)
            .ToList();
    }
}
