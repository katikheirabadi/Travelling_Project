using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravellingCore.Dto.City.AddCity;
using TravellingCore.Services.Models.Services.CityService;
using TravellingCore.Services.Models.Services.CountryService;

namespace Travellingfront.Pages.Admins.Cities
{
    public class AddModel : PageModel
    {
        private readonly ICityService cityService;
        private readonly ICountryService countryService;

        [BindProperty]
        public AddCityInputDto NewCity { get; set; }
        [BindProperty]
        public bool State { get; set; }

        public AddModel(ICityService cityService,
                        ICountryService countryService)
        {
            this.cityService = cityService;
            this.countryService = countryService;
        }
        public async Task OnGet()
        {
            var countries = await countryService.GetAll();
            ViewData["countries"] = new SelectList(countries, "Name", "Name");
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                await cityService.Addcity(NewCity);
                State = true;
                return RedirectToPage("./City");
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
