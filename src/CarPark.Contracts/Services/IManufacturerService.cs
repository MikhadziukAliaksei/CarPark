using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Contracts.Services
{
    public interface IManufacturerService
    {
        IEnumerable<ManufacturerCountry> GetManufacturers(bool trackChanges);

        ManufacturerCountry GetManufacturer(int id, bool trackChanges);

        void CreateManufacturer(ManufacturerCountry car);

        void DeleteManufacturer(ManufacturerCountry car);

        void UpdateManufacturer();
    }
}
