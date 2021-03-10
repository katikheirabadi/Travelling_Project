using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.LogIn;
using TravellingCore.Services.LoginService;

namespace Travellingfront.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ILoginServicecs loginServicecs;

        public LoginModel(ILoginServicecs loginServicecs)
        {
            this.loginServicecs = loginServicecs;
        }
        [BindProperty]
        public LoginInputDto NewUserLogin { get; set; }

        [BindProperty]
        public string Token { get; set; }

        [BindProperty]
        public bool State { get; set; }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                Token =await loginServicecs.AddLogin(NewUserLogin);
                State = true;
                return RedirectToPage("/Index");
            }
            catch(Exception e)
            {
                State = false;
                ViewData["Error"] = e.Message;
                return Page();
            }
        }
    }
}
