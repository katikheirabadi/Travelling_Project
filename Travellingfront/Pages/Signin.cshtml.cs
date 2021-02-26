using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Services.SigninServicefoulder;

namespace Travellingfront.Pages
{
    public class SigninModel : PageModel
    {
        private readonly IUserService userService;

        [BindProperty]
        public SigninInputDTO Signin { get; set; }
        public SigninModel(IUserService userService)
        {
            this.userService = userService;
            
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            await userService.AddUser(Signin);
            return RedirectToPage("/Index");
           
        }
       
    }
}
