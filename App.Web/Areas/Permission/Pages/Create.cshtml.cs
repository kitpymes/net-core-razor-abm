using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using App.Database;
using System.Threading.Tasks;

namespace App.Web.Permission
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> _logger;
        private readonly IAppDbContext _context;

        public CreateModel(
            ILogger<CreateModel> logger,
            IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Models.Permission Permision { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            await _context.Permision.AddAsync(Permision);

            await _context.SaveAsync();

            return RedirectToPage("./Index");
        }
    }
}
