using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Permisos.Models;

namespace Permisos.Database
{
    public class PermisosRepository : GenericRepository<Models.Permisos>, IPermisosRepository
    {
        public PermisosRepository(PermisosContext dbContext)
            : base(dbContext)
        {

        }

        public List<Models.Permisos> GetAllWithTipoPermiso()
        {
            return _dbContext.Permisos.Include(i => i.TipoPermiso).ToList();
        }

        public Models.Permisos GetByIdWithTipoPermiso(int id)
        {
            return _dbContext.Permisos.Include(i => i.TipoPermiso).FirstOrDefault(x => x.Id == id );
        }
    }
}
