using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.City.GetCitybyId;
using TravellingCore.Services.Models.Services.CityService;

namespace Travellingfront.Pages
{
    public class CityModel : PageModel
    {
        private readonly ICityService cityService;

        public CityModel(ICityService cityService)
        {
            this.cityService = cityService;
        }
        [BindProperty]
        public GetCityByIdOutputDto City { get; set; }


        public async Task OnGet(int id)
        {
            City = await cityService.GetcityById(id);
        }
    }
}
