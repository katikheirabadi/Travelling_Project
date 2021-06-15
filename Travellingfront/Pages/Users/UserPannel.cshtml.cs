using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Favorites;
using TravellingCore.Dto.SearchByFilter;
using TravellingCore.Model;
using TravellingCore.Services.FavoriteService;
using TravellingCore.Services.SigninServicefoulder;

namespace Travellingfront.Pages.Users
{
    public class UserPannelModel : PageModel
    {
        private readonly UserManager<User> userManager;
        private readonly IFavoriteService favoriteService;

        [BindProperty]
        public List<FilterOutputDetailDTO> Recommendeds { get; set; }

        public bool State { get; set; }
        public UserPannelModel(UserManager<User> userManager
                               ,IFavoriteService favoriteService)
        {
            this.userManager = userManager;
            this.favoriteService = favoriteService;
        }
        public User Me { get; set; }
        public async Task OnGet()
        {
            try
            {
                Me = await userManager.GetUserAsync(HttpContext.User);
                Recommendeds = await favoriteService.ReccomendedByFavorite(Me.Id);
                State = true;
            }
            catch (Exception e)
            {
                State = false;

            }
           
        }
    }
}
