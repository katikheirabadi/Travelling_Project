using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.TuristPlace.GetPlace;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages
{
    public class PlaceModel : PageModel
    {
        private readonly ITuristPlaceService turistPlaceService;

        [BindProperty]
        public GetPlaceOutputDto getPlace { get; set; }
        public PlaceModel(ITuristPlaceService turistPlaceService)
        {
            this.turistPlaceService = turistPlaceService;
        }
        public async Task<IActionResult> OnGet(int id)
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
