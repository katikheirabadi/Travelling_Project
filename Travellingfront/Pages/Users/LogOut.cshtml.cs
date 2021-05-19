using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Travellingfront.Pages.Users
{
    public class LogOutModel : PageModel
    {
        private readonly SignInManager<TravellingCore.Model.User> _signInManager;
        private readonly ILogger<LogOutModel> _logger;

        public LogOutModel(SignInManager<TravellingCore.Model.User> signInManager, ILogger<LogOutModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string returnUrl = null)
        {
            try
            {
                await _signInManager.SignOutAsync();
                _logger.LogInformation("User logged out.");
                if (returnUrl != null)
                {
                    return LocalRedirect(returnUrl);
                }
                else
                {
                    return RedirectToPage();
                }
            }
            catch (Exception e)
            {

                ViewData["error"] = e.Message;
                return Page();
            }
        }
    }
}
