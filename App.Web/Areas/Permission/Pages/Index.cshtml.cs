using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using App.Database;

namespace App.Web.Permission
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IAppDbContext _context;

        public IndexModel(
            ILogger<IndexModel> logger,
            IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Models.Permission> Permissions { get; set; }

        public async Task OnGetAsync()
        {
            Permissions = await _context.Permision
               .Include(x => x.PermissionType)
               .ToListAsync();
        }
    }
}

