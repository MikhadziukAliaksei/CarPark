using CarPark.Contracts.Interfaces;
using CarPark.Entities.Context;
using CarPark.Entities.Models;
using CarPark.Entities.RequestFeatures;
using CarPark.Repository.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

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


        public async Task<PagedList<Car>> GetCarsAsync(CarsParameter carsParameters, bool trackChanges)
        {
            var cars = await GetAll(trackChanges)
                .FilterCars(carsParameters.MinYearOfIssue, carsParameters.MaxYearOfIssue)
                .Search(carsParameters.SearchTerm)
                .Sort(carsParameters.OrderBy)
                .ToListAsync();

            return PagedList<Car>.ToPagedList(cars, carsParameters.PageNumber, carsParameters.PageSize);
        }

        public void UpdateCar(Car car) => Edit(car);
    }
}
