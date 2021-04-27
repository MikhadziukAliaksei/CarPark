using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Contracts.Services
{
    public interface IOrderService
    {
        IEnumerable<Order> GetOrders(bool trackChanges);

        Order GetOrder(int id, bool trackChanges);

        void CreateOrder(Order order);

        void DeleteOrder(Order order, bool trackChanges);

        void UpdateOrder();
    }
}
