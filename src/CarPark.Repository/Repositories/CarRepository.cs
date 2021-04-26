using CarPark.Contracts.Interfaces;
using CarPark.Entities.Context;
using CarPark.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarPark.Repository.Repositories
{
    public class CarRepository : RepositoryBase<Car>, ICarRepository
    {
        public CarRepository(ApplicationContext _applicationContext)
            : base(_applicationContext)
        {
        }

        public void CreateCar(Car car) => Create(car);

        public void DeleteCar(int id, bool trackChanges)
        {
            var carEntity = GetCar(id, trackChanges);
            carEntity.IsDeleted = true;
            Save();
        }


        public Car GetCar(int id, bool trackChanges) =>
            FindByConditions(item => item.Id.Equals(id), trackChanges)
            .SingleOrDefault();
             
        

        public IEnumerable<Car> GetCars(bool trackChanges) =>
            GetAll(trackChanges)
            .Where(item => !item.IsDeleted)
            .OrderBy(item => item.Mark)
            .ToList();

        public void UpdateCar(Car car) => Edit(car);
    }
}
