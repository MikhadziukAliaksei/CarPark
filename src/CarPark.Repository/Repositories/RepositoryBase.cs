
namespace CarPark.Repository.Repositories
{
    public abstract class RepositoryBase<Entity> : IRepository<Entity>
        where Entity : class
    {
    }
}
