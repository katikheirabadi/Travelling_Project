using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravellingCore.Dto.City.GetAll;
using TravellingCore.Dto.Country.GetAllCountries;
using TravellingCore.Dto.SearchByFilter;
using TravellingCore.Services.Models.Services.CityService;
using TravellingCore.Services.Models.Services.CountryService;
using TravellingCore.Services.Models.Services.SearchServise;

namespace Travellingfront.Pages
{
    public class SearchResultModel : PageModel
    {
        private readonly ICountryService countryService;
        private readonly ICityService cityService;
        private readonly ISearchservise searchservise;

        public SearchResultModel(ICountryService countryService,
                                 ICityService cityService,
                                 ISearchservise searchservise)
        {
            this.countryService = countryService;
            this.cityService = cityService;
            this.searchservise = searchservise;
        }

        [BindProperty]
        public List<GetAllcountries> countries { get; set; }
        [BindProperty]
        public List<GetAllOutputDto> cities { get; set; }
        [BindProperty]
        public List<FilterOutputDetailDTO> result { get; set; }
        
        public bool state { get; set; }
        public async Task OnGet()
        {
            countries = await countryService.GetAll();
            cities = await cityService.GetAll();

            ViewData["country"] = new SelectList(countries, "Id", "Name");
            ViewData["city"] = new SelectList(cities, "Id", "Name");
        }
    }
}
