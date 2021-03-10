using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Coment;
using TravellingCore.Dto.TuristPlace.GetPlace;
using TravellingCore.Dto.TuristPlaces.GetPlaceWithId;
using TravellingCore.Services.Models.Services.CommentServise;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages
{
    public class PlaceModel : PageModel
    {
        private readonly ITuristPlaceService turistPlaceService;
        private readonly ICommentService commentService;

        [BindProperty]
        public GetplaceWithIdOutputDto getPlace { get; set; }

        [BindProperty]
        public bool State { get; set; }

        public PlaceModel(ITuristPlaceService turistPlaceService,
                          ICommentService commentService)
        {
            this.turistPlaceService = turistPlaceService;
            this.commentService = commentService;
        }
        public async Task<IActionResult> OnGet(int id , string Token)
        {
            getPlace = await turistPlaceService.GetByid(id);
           
            if (getPlace == null)
            {
                return NotFound();
            }
          
            return Page();
        }
       
    }
}
