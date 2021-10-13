using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using App.Database;
using System.Threading.Tasks;

namespace App.Web.Permission
{
    public class RemoveModel : PageModel
    {
        private readonly ILogger<RemoveModel> _logger;
        private readonly IAppDbContext _context;

        public RemoveModel(
            ILogger<RemoveModel> logger,
            IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [BindProperty]
        public Models.Permission Permission { get; set; }
        public string ErrorMessage { get; set; }

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
            try
            {
                var permission = await _context.Permision
                  .Include(x => x.PermissionType)
                  .FirstOrDefaultAsync(x => x.Id == id);

                if (permission is null)
                {
                    return NotFound();
                }

                _context.Permision.Remove(permission);

                await _context.SaveAsync();

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
