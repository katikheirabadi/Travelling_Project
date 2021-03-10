using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Country.Get_CountrywithId;
using TravellingCore.Services.Models.Services.CategoryServise;
using TravellingCore.Services.Models.Services.CountryService;

namespace Travellingfront.Pages
{
    public class CountryModel : PageModel
    {
        private readonly ICountryService countryservice;

        public CountryModel(ICountryService countryservice)
        {
            this.countryservice = countryservice;
        }

        [BindProperty]
        public GetCountryWithIdOutputDto Country { get; set; }

        public async Task OnGet(int id)
        {
            Country = await countryservice.GetCountryWithId(id);
        }
    }
}
