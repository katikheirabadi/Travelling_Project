using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.TuristPlaces.GetAll;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages.Admins.Places
{
    public class PlaceModel : PageModel
    {
        private readonly ITuristPlaceService turistPlaceService;

        [BindProperty]
        public List<GetAllPlaces> places { get; set; }

        public PlaceModel(ITuristPlaceService turistPlaceService)
        {
            this.turistPlaceService = turistPlaceService;
        }
        public async Task OnGet()
        {
            places = await turistPlaceService.ShowAll();
        }
    }
}
