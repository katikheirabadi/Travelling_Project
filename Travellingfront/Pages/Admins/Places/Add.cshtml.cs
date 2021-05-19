using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravellingCore.Dto.TuristPlace.AddPlace;
using TravellingCore.Services.Models.Services.CityService;
using TravellingCore.Services.Models.Services.CountryService;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages.Admins.Places
{
    public class AddModel : PageModel
    {
        private readonly ITuristPlaceService turistPlaceService;
        private readonly ICountryService countryService;
        private readonly ICityService cityService;

        [BindProperty]
        public AddPlaceInputDto placeinput { get; set; }

        [BindProperty]
        public bool State { get; set; }

        public AddModel(ITuristPlaceService turistPlaceService,
                        ICountryService countryService,
                        ICityService cityService)
        {
            this.turistPlaceService = turistPlaceService;
            this.countryService = countryService;
            this.cityService = cityService;
        }
        public async Task OnGet()
        {
            var cities = await cityService.GetAll();
            var countries = await countryService.GetAll();

            ViewData["country"] = new SelectList(countries, "Name", "Name");
            ViewData["city"] = new SelectList(cities, "Name", "Name");

        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                await turistPlaceService.AddTuristPlace(placeinput);
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
