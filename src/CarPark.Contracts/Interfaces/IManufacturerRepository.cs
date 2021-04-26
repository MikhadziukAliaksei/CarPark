using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Contracts.Interfaces
{
    public interface IManufacturerRepository
    {
        IEnumerable<ManufacturerCountry> GetManufacturers(bool trackChanges);

        ManufacturerCountry GetManufacturer(int id, bool trackChanges);

        void CreateManufacturer(ManufacturerCountry manufacturer);

        void DeleteManufacturer(ManufacturerCountry manufacturer);

        void UpdateManufacturer(ManufacturerCountry manufacturer);
    }
}
