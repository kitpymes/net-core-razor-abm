using System.Linq;
using System.Threading.Tasks;

namespace Permisos.Database
{
    public interface IGenericRepository<TEntity>
        where TEntity : Models.EntityBase
    {
        IQueryable<TEntity> GetAll();
        TEntity GetById(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        Task SaveAsync();
    }
}
