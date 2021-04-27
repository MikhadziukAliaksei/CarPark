using CarPark.Contracts.Interfaces;
using CarPark.Entities.Context;
using CarPark.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace CarPark.Repository.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext applicationContext)
            : base(applicationContext)
        {

        }

        public void CreateOrder(Order order) => Create(order);

        public void DeleteOrder(int id, bool trackChanges)
        {
            var orderEntity = GetOrder( id,  trackChanges);
            orderEntity.IsDeleted = true;
            Save();
        }

        public Order GetOrder(int id, bool trackChanges) =>
              FindByConditions(item => item.Id.Equals(id), trackChanges)
              .SingleOrDefault();


        public IEnumerable<Order> GetOrders(bool trackChanges) =>
             GetAll(trackChanges)
            .Where(item => !item.IsDeleted)
            .OrderBy(item => item.Id)
            .ToList();


        public void UpdateOrder(Order order) => Edit(order);
    }
}
