using CarPark.Contracts.Interfaces;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using System;
using System.Collections.Generic;

namespace CarPark.Bll.Services
{
    public class ManufacturerService : IManufacturerService
    {
        private readonly IRepositoryManager _repositoryManager;

        public ManufacturerService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void CreateManufacturer(ManufacturerCountry manufacturer)
        {
            _repositoryManager.Manufacturer.CreateManufacturer(manufacturer);
            _repositoryManager.Save();
        }
       

        public void DeleteManufacturer(ManufacturerCountry manufacturer)
        {
            _repositoryManager.Manufacturer.DeleteManufacturer(manufacturer);
            _repositoryManager.Save();
        }

        public IEnumerable<ManufacturerCountry> GetManufacturers(bool trackChanges)
        {
            return _repositoryManager.Manufacturer.GetManufacturers(trackChanges);
        }

        public ManufacturerCountry GetManufacturer(int id, bool trackChanges)
        {
            return _repositoryManager.Manufacturer.GetManufacturer(id, trackChanges);
        }

        public void UpdateManufacturer()
        {
            _repositoryManager.Save();
        }
    }
}
