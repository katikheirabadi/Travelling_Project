using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Country.GetAllCountries;
using TravellingCore.Services.Models.Services.CountryService;

namespace Travellingfront.Pages.Admins.Countries
{
    public class CountryModel : PageModel
    {
        private readonly ICountryService countryService;

        [BindProperty]
        public List<GetAllcountries> Countries { get; set; }

        public CountryModel(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        public async Task OnGet()
        {
           Countries = await countryService.GetAll();
        }
    }
}
