using System.Threading.Tasks;

namespace Solo.Base.Data
{
    public interface IRepository<TEntity> where TEntity: class 
    {
        // void Add<TEntity>(TEntity entity, bool saveNow = true) where TEntity: class , IEntity;
        Task<bool> Add(TEntity entity);
    }
}