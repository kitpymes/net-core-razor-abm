using System.Collections.Generic;

namespace Permisos.Database
{
    public interface IPermisosRepository : IGenericRepository<Models.Permisos>
    {
        List<Models.Permisos> GetAllWithTipoPermiso();

        Models.Permisos GetByIdWithTipoPermiso(int id);
    }
}
