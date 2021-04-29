using CarPark.Contracts.Interfaces;
using CarPark.Entities.Context;
using CarPark.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarPark.Repository.Repositories
{
    public class CarParkRepository : RepositoryBase<BranchCarPark>, ICarParkRepository
    {
        public CarParkRepository(ApplicationContext _applicationContext)
           : base(_applicationContext)
        {
        }
        public void CreateCarPark(BranchCarPark carPark) => Create(carPark);

        public void DeleteCarPark(BranchCarPark carPark) => Delete(carPark);

        public BranchCarPark GetCarPark(int id, bool trackChanges) =>
            FindByConditions(item => item.Id.Equals(id), trackChanges)
            .SingleOrDefault();


        public IEnumerable<BranchCarPark> GetCarParks(bool trackChanges) =>
             GetAll(trackChanges)
            .OrderBy(item => item.Name)
            .ToList();

        public void UpdateCarPark(BranchCarPark carPark) => Edit(carPark);
    }
}
