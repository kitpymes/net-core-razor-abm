using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Permisos.Database;

namespace Permisos
{
    public class EditarPermisoModel : PageModel
    {
        private readonly ILogger<EditarPermisoModel> _logger;

        private readonly IPermisosRepository _repository;

        public EditarPermisoModel(ILogger<EditarPermisoModel> logger, IPermisosRepository repository)
        {
            _logger = logger;

            _repository = repository;
        }

        [BindProperty]
        public Models.Permisos Permiso { get; set; }

        public IActionResult OnGet(int id)
        {
            Permiso = _repository.GetByIdWithTipoPermiso(id);

            if (Permiso is null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var permisoToUpdate = _repository.GetByIdWithTipoPermiso(id);

            permisoToUpdate.NombreEmpleado = Permiso.NombreEmpleado;
            permisoToUpdate.ApellidoEmpleado = Permiso.ApellidoEmpleado;
            permisoToUpdate.FechaPermiso = Permiso.FechaPermiso;
            permisoToUpdate.TipoPermisoId = Permiso.TipoPermisoId;

            _repository.Update(permisoToUpdate);

            return RedirectToPage("./Index");
        }
    }
}