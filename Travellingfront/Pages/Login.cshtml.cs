using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TravellingCore.Dto.LogIn;

namespace Travellingfront.Pages
{
    public class LoginModel : PageModel
    {
        private readonly SignInManager<TravellingCore.Model.User> signInManager;
        private readonly UserManager<TravellingCore.Model.User> userManager;
        private readonly ILogger<LoginModel> logger;

        public LoginModel(SignInManager<TravellingCore.Model.User> signInManager,
                          UserManager<TravellingCore.Model.User> userManager,
                          ILogger<LoginModel> logger)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.logger = logger;
        }
        [BindProperty]
        public LoginInputDto NewUserLogin { get; set; }
        public bool State { get; set; }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            try
            {
                returnUrl = returnUrl ?? Url.Content("~/");

                if (ModelState.IsValid)
                {
                    // This doesn't count login failures towards account lockout
                    // To enable password failures to trigger account lockout, 
                    // set lockoutOnFailure: true
                    var result = await signInManager.PasswordSignInAsync(NewUserLogin.Username,
                                       NewUserLogin.Password, NewUserLogin.Remember, lockoutOnFailure: true);
                    if (result.Succeeded)
                    {
                        logger.LogInformation("User logged in.");
                        return LocalRedirect(returnUrl);
                    }
                    if (result.IsLockedOut)
                    {
                        logger.LogWarning("User account locked out.");
                        return RedirectToPage("./Lockout");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                        return Page();
                    }
                }
                State = true;
                // If we got this far, something failed, redisplay form
                return Page();
            }
            catch (Exception e)
            {
                ViewData["error"] = e.Message;
                State = false;
                return Page();
            }
        }
      
    }
}
