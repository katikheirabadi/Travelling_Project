using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.TuristPlace.UpdatePlace;
using TravellingCore.Dto.TuristPlaces.GetPlaceWithId;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages.Admins.Places
{
    public class UpdateModel : PageModel
    {
        private readonly ITuristPlaceService turistPlaceService;

        [BindProperty]
        public GetplaceWithIdOutputDto Place { get; set; }

        [BindProperty]
        public UpdatePlaceInputDto UpdatePlace { get; set; }
        [ModelBinder]
        public bool State { get; set; }
         
        public UpdateModel(ITuristPlaceService turistPlaceService)
        {
            this.turistPlaceService = turistPlaceService;
        }
        public async Task OnGet(int id)
        {
            Place = await turistPlaceService.GetByid(id);
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                await turistPlaceService.UpdatePlace(UpdatePlace);
                State = true;
                return RedirectToPage("./Place");
            }
            catch (Exception e)
            {
                State = false;
                ViewData["Error"] = e.Message;
                return Page();
            }
            
        }
    }
}
