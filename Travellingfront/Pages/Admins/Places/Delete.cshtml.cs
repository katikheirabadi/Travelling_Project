using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.TuristPlace.DeletePlace;
using TravellingCore.Dto.TuristPlaces.GetPlaceWithId;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages.Admins.Places
{
    public class DeleteModel : PageModel
    {
        private readonly ITuristPlaceService turistPlaceService;

        [BindProperty]
        public GetplaceWithIdOutputDto getitem { get; set; }

        public DeleteModel(ITuristPlaceService turistPlaceService)
        {
            this.turistPlaceService = turistPlaceService;
        }
        public async Task OnGet(int id)
        {
            getitem = await turistPlaceService.GetByid(id);
            await turistPlaceService.DeleteById(id);

        }
       
    }
}
