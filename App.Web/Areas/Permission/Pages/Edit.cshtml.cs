using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using App.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace App.Web.Permission
{
    public class EditModel : PageModel
    {
        private readonly ILogger<EditModel> _logger;

        private readonly IAppDbContext _context;

        public EditModel(
            ILogger<EditModel> logger,
            IAppDbContext context)
        {
            _logger = logger;

            _context = context;
        }

        [BindProperty]
        public Models.Permission Permission { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Permission = await _context.Permision
                .Include(x => x.PermissionType)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (Permission is null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var permisoToUpdate = await _context.Permision
                .Include(x => x.PermissionType)
                .FirstOrDefaultAsync(x => x.Id == id);

            permisoToUpdate.Name = Permission.Name;
            permisoToUpdate.Surname = Permission.Surname;
            permisoToUpdate.Date = Permission.Date;
            permisoToUpdate.PermissionTypeId = Permission.PermissionTypeId;

            _context.Permision.Update(permisoToUpdate);

            await _context.SaveAsync();

            return RedirectToPage("./Index");
        }
    }
}
