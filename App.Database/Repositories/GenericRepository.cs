using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace App.Database
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
    where TEntity : Models.EntityBase
    {
        protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        => _dbContext = dbContext;

        public IQueryable<TEntity> GetAll()
        => _dbContext.Set<TEntity>().AsNoTracking();

        public TEntity GetById(int id)
        => _dbContext.Set<TEntity>()
            .AsNoTracking()
            .FirstOrDefault(e => e.Id == id);

        public void Create(TEntity entity)
        {
            _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _dbContext.Set<TEntity>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public async Task SaveAsync()
        => await _dbContext.SaveChangesAsync();
    }
}
