using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Services.LoginService;
using TravellingCore.Services.Models.Services.CategoryServise;
using TravellingCore.Services.Models.Services.CityService;
using TravellingCore.Services.Models.Services.CommentServise;
using TravellingCore.Services.Models.Services.CountryService;
using TravellingCore.Services.Models.Services.RateService;
using TravellingCore.Services.Models.Services.TuristPlaceService;
using TravellingCore.Services.SigninServicefoulder;

namespace Travellingfront.Pages.Admins
{
    public class AdminpannelModel : PageModel
    {
        private readonly ITuristPlaceService turistPlaceService;
        private readonly ICategoryServise categoryServise;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly ICommentService commentService;
        private readonly IRateService rateService;
        private readonly IUserService userService;
        private readonly ILoginServicecs loginServicecs;

        [BindProperty]
        public int PlaceNumber { get; set; }
        [BindProperty]
        public int categoryNumber { get; set; }
        [BindProperty]
        public int CountryNumber { get; set; }
        [BindProperty]
        public int CityNumber { get; set; }
        [BindProperty]
        public int CommentNumber { get; set; }
        [BindProperty]
        public int RateNumber { get; set; }
        [BindProperty]
        public int UserNumber { get; set; }
        [BindProperty]
        public int LoginNumber { get; set; }

        public AdminpannelModel(ITuristPlaceService TuristPlaceService,
                                ICategoryServise categoryServise,
                                ICountryService countryService,
                                ICityService cityService,
                                ICommentService commentService,
                                IRateService rateService,
                                IUserService userService,
                                ILoginServicecs loginServicecs)
        {
            turistPlaceService = TuristPlaceService;
            this.categoryServise = categoryServise;
            this.countryService = countryService;
            this.cityService = cityService;
            this.commentService = commentService;
            this.rateService = rateService;
            this.userService = userService;
            this.loginServicecs = loginServicecs;
        }
        public  async Task OnGet()
        {
            var placelist = await turistPlaceService.GetAllPlaces();
            PlaceNumber = placelist.Count;

            var categorylist = await categoryServise.GetAll();
            categoryNumber = categorylist.Count;

            var countrylist = await countryService.GetAll();
            CountryNumber = countrylist.Count;

            var citylist = await cityService.GetAll();
            CityNumber = citylist.Count;

            var commentlist = await commentService.ShowAllComments();
            CommentNumber = commentlist.Count;

            var ratelist = await rateService.GetAllRate();
            RateNumber = ratelist.Count;

            var usernumbers = await userService.ShowAllUser();
            UserNumber = usernumbers.Count;

            var loginlist = await loginServicecs.ShowAllUserLogin();
            LoginNumber = loginlist.Count;
        }
    }
}
