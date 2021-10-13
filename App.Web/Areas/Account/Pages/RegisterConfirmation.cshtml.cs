using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Web.Account
{
    public class RegisterConfirmationModel : PageModel
    {
        private readonly ILogger<RegisterConfirmationModel> _logger;

        private readonly IAppDbContext _context;

        public RegisterConfirmationModel(
          ILogger<RegisterConfirmationModel> logger,
          IAppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public string Email { get; set; }

        public async Task<IActionResult> OnGetAsync(string email)
        {
            if (email == null)
            {
                return RedirectToPage("/Index");
            }

            var user = await _context.User.FirstOrDefaultAsync(f => f.Email == email);
            
            if (user == null)
            {
                return NotFound($"Unable to load user with email '{email}'.");
            }

            Email = email;

            return Page();
        }
    }
}
