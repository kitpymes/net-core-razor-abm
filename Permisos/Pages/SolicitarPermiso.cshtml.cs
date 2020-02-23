using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Permisos.Database;

namespace Permisos.Pages
{
    public class SolicitarPermisoModel : PageModel
    {
        private readonly ILogger<SolicitarPermisoModel> _logger;

        private readonly IPermisosRepository _repository;

        public SolicitarPermisoModel(ILogger<SolicitarPermisoModel> logger, IPermisosRepository repository)
        {
            _logger = logger;

            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Permisos Permiso { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _repository.Create(Permiso);

            return RedirectToPage("./Index");
        }
    }
}