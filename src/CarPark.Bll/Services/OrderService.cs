using CarPark.Contracts.Interfaces;
using CarPark.Contracts.Services;
using CarPark.Entities.Models;
using System.Collections.Generic;

namespace CarPark.Bll.Services
{
    public class OrderService : IOrderService
    {
        private readonly IRepositoryManager _repositoryManager;

        public OrderService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public void CreateOrder(Order order)
        {
            _repositoryManager.Order.CreateOrder(order);
            _repositoryManager.Save();
        }

        public void DeleteOrder(Order order, bool trackChanges)
        {
            _repositoryManager.Order.DeleteOrder(order.Id, trackChanges);
        }

        public Order GetOrder(int id, bool trackChanges)
        {
           return _repositoryManager.Order.GetOrder(id, trackChanges);   
        }

        public IEnumerable<Order> GetOrders(bool trackChanges)
        {
            var orders = _repositoryManager.Order.GetOrders(trackChanges);
            return orders;
        }

        public void UpdateOrder()
        {
            _repositoryManager.Save();
        }
    }
}
