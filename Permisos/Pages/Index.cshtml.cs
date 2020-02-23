using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Permisos.Database;

namespace Permisos.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        private readonly IPermisosRepository _repository;

        public IndexModel(ILogger<IndexModel> logger, IPermisosRepository repository)
        {
            _logger = logger;

            _repository = repository;
        }

        public IList<Models.Permisos> Permisos { get; set; }

        public void OnGet()
        {
            Permisos = _repository.GetAllWithTipoPermiso();
        }
    }
}
