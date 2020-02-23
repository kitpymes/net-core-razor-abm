using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Permisos.Database;


namespace Permisos.Pages
{
    public class EliminarPermisoModel : PageModel
    {
        private readonly ILogger<EliminarPermisoModel> _logger;

        private readonly IPermisosRepository _repository;

        public EliminarPermisoModel(ILogger<EliminarPermisoModel> logger, IPermisosRepository repository)
        {
            _logger = logger;

            _repository = repository;
        }

        [BindProperty]
        public Models.Permisos Permiso { get; set; }
        public string ErrorMessage { get; set; }

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
            try
            {
                _repository.Delete(id);

                return RedirectToPage("./Index");
            }
            catch (DbUpdateException /* ex */)
            {
                //Log the error (uncomment ex variable name and write a log.)
                return RedirectToAction("./Delete",
                                     new { id, saveChangesError = true });
            }
        }
    }
}