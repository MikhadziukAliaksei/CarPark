using CarPark.Contracts.Interfaces;
using CarPark.Entities.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace CarPark.Repository.Repositories
{
    public abstract class RepositoryBase<Entity> : IRepository<Entity>
        where Entity : class
    {
        protected ApplicationContext ApplicationContext;

        public RepositoryBase(ApplicationContext applicationContext)
        {
            ApplicationContext = applicationContext;
        }

        public void Create(Entity entity) => ApplicationContext.Set<Entity>().Add(entity);

        public void Delete(Entity entity) => ApplicationContext.Set<Entity>().Remove(entity);

        public void Edit(Entity entity) => ApplicationContext.Set<Entity>().Update(entity);


        public IQueryable<Entity> FindByConditions(Expression<Func<Entity, bool>> expression, bool trackChanges) =>
            !trackChanges ?
            ApplicationContext.Set<Entity>().Where(expression)
            .AsNoTracking() :
            ApplicationContext.Set<Entity>().Where(expression);

        public IQueryable<Entity> GetAll(bool trackChanges) =>
            !trackChanges ?
            ApplicationContext.Set<Entity>().AsNoTracking() :
            ApplicationContext.Set<Entity>();

        public void Save()
        {
            ApplicationContext.SaveChanges();
        }
             
    }
}
