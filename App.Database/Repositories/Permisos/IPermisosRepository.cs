using System.Collections.Generic;

namespace App.Database
{
    public interface IPermisosRepository : IGenericRepository<Models.Permisos>
    {
        List<Models.Permisos> GetAllWithTipoPermiso();

        Models.Permisos GetByIdWithTipoPermiso(int id);
    }
}
