using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using App.Database;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace App.Web.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly ILogger<RegisterModel> _logger;

        private readonly IAppDbContext _context;

        public RegisterModel(
            ILogger<RegisterModel> logger,
            IAppDbContext context)
        {
            _logger = logger;

            _context = context;
        }

        [BindProperty]
        public RegisterInput Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public void OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var user = _context.User.FirstOrDefault(f => f.Email == Input.Email);

            if (user != null)
            {
                ModelState.AddModelError(string.Empty, Input.Email + " Alrready exists");

                return Page();
            }

            user = new Models.User { Email = Input.Email, Password = Input.Password };

            await _context.User.AddAsync(user);

            await _context.SaveAsync();

            return RedirectToPage("RegisterConfirmation", new { email = Input.Email });
        }
    }
}