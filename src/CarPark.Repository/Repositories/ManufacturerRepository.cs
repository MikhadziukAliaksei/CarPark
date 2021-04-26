using CarPark.Contracts.Interfaces;
using CarPark.Entities.Context;
using CarPark.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarPark.Repository.Repositories
{
    public class ManufacturerRepository : RepositoryBase<ManufacturerCountry>, IManufacturerRepository
    {
        public ManufacturerRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {
               
        }

        public void CreateManufacturer(ManufacturerCountry manufacturer) => Create(manufacturer);

        public void DeleteManufacturer(ManufacturerCountry manufacturer) => Delete(manufacturer);

        public ManufacturerCountry GetManufacturer(int id, bool trackChanges) =>
             FindByConditions(item => item.Id.Equals(id), trackChanges)
            .SingleOrDefault();

        public IEnumerable<ManufacturerCountry> GetManufacturers(bool trackChanges) =>
             GetAll(trackChanges)
            .OrderBy(item => item.Name)
            .ToList();

        public void UpdateManufacturer(ManufacturerCountry manufacturer) => Edit(manufacturer);
    }
}
