using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Model;
using TravellingCore.Services.SigninServicefoulder;

namespace Travellingfront.Pages.Users
{
    public class UserPannelModel : PageModel
    {
        private readonly UserManager<User> userManager;

        public UserPannelModel(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }
        public User Me { get; set; }
        public async Task OnGet()
        {
           Me = await userManager.GetUserAsync(HttpContext.User);
        }
    }
}
