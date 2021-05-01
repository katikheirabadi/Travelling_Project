using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Country.AddCountry;
using TravellingCore.Services.Models.Services.CountryService;

namespace Travellingfront.Pages.Admins.Countries
{
    public class AddModel : PageModel
    {
        private readonly ICountryService countryService;

        [BindProperty]
        public bool State { get; set; }
        [BindProperty]
        public AddCountryInputDto NewCountry { get; set; }
        public AddModel(ICountryService countryService)
        {
            this.countryService = countryService;
        }
       public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                await countryService.AddCountry(NewCountry);
                State = true;
                return RedirectToPage("./Country");

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
