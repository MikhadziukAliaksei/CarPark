using System;
using System.Linq;
using System.Linq.Expressions;

namespace CarPark.Contracts.Interfaces
{
    public interface IRepository<Entity>
    {
        IQueryable<Entity> GetAll(bool trackChanges);

        IQueryable<Entity> FindByConditions(Expression<Func<Entity, bool>> expression, bool trackChanges);

        void Create(Entity entity);

        void Delete(Entity entity);

        void Edit(Entity entity);
    }
}
