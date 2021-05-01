using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Services.SigninServicefoulder;

namespace Travellingfront.Pages
{
    public class UserPannelModel : PageModel
    {
        private readonly IUserService userService;

        [BindProperty]
        public bool FavoriteState { get; set; }

        public UserPannelModel(IUserService userService)
        {
            this.userService = userService;
        }
        public void OnGet(int id)
        {

        }
    }
}
