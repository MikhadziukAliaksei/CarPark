using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Contracts.Interfaces
{
    public interface IOrderRepository
    {
        IEnumerable<Order> GetOrders(bool trackChanges);

        Order GetOrder(int id, bool trackChanges);

        void CreateOrder(Order order);

        void DeleteOrder(int id, bool trackChanges);

        void UpdateOrder(Order order);
    }
}
