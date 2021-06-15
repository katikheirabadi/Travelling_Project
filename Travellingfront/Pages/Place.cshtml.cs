using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Coment;
using TravellingCore.Dto.Coment.GetPlaceComment;
using TravellingCore.Dto.Rate;
using TravellingCore.Dto.TuristPlace.GetPlace;
using TravellingCore.Dto.TuristPlaces.GetPlaceWithId;
using TravellingCore.Model;
using TravellingCore.Services.Models.Services.CommentServise;
using TravellingCore.Services.Models.Services.RateService;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages
{
    public class PlaceModel : PageModel
    {
        private readonly ITuristPlaceService turistPlaceService;
        private readonly ICommentService commentService;
        private readonly IRateService rateService;
        private readonly UserManager<User> userManager;

        [BindProperty]
        public GetplaceWithIdOutputDto getPlace { get; set; }
        [BindProperty]
        public List<GetPlacecommentsOutputDto> PlacesComment { get; set; }
        [BindProperty]
        public User CurrentUser { get; set; }
        [BindProperty]
        public  static int PlaceId { get; set; }

        public PlaceModel(ITuristPlaceService turistPlaceService,
                          ICommentService commentService,
                          UserManager<User> userManager)
        {
            this.turistPlaceService = turistPlaceService;
            this.commentService = commentService;
            this.rateService = rateService;
            this.userManager = userManager;
        }
        public async Task OnGet(int id)
        {
            getPlace = await turistPlaceService.GetByid(id);
            PlacesComment = await commentService.ShowPlaceComments(new GetPlaceCommentsInputDto() {  TuristPlaceName = getPlace.Name});
            CurrentUser = await userManager.GetUserAsync(HttpContext.User);
            PlaceId = id;
        }

    }
}
