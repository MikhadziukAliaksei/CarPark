using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Contracts.Services
{
    public interface ICarParkService
    {
        IEnumerable<BranchCarPark> GetCarParks(bool trackChanges);

        BranchCarPark GetCarPark(int id, bool trackChanges);

        void CreateCarPark(BranchCarPark carPark);

        void DeleteCarPark(BranchCarPark carPark);

        void UpdateCarPark();
    }
}
