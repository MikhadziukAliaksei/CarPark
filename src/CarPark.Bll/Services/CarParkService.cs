using CarPark.Contracts.Interfaces;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Bll.Services
{
    public class CarParkService : ICarParkService
    {
        private readonly IRepositoryManager _repositoryManager;

        public CarParkService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void CreateCarPark(BranchCarPark carPark)
        {
            _repositoryManager.CarPark.CreateCarPark(carPark);
            _repositoryManager.Save();
        }

        public void DeleteCarPark(BranchCarPark carPark)
        {
            _repositoryManager.CarPark.DeleteCarPark(carPark);
            _repositoryManager.Save();
        }

        public BranchCarPark GetCarPark(int id, bool trackChanges)
        {
            return _repositoryManager.CarPark.GetCarPark(id, trackChanges);
        }

        public IEnumerable<BranchCarPark> GetCarParks(bool trackChanges)
        {
            var carParks = _repositoryManager.CarPark.GetCarParks(trackChanges);
            return carParks;
        }

        public void UpdateCarPark()
        {
            _repositoryManager.Save();
        }
    }
}
