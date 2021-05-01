using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.City.GetAll;
using TravellingCore.Services.Models.Services.CityService;

namespace Travellingfront.Pages.Admins.Cities
{
    public class CityModel : PageModel
    {
        private readonly ICityService cityService;
        [BindProperty]
        public List<GetAllOutputDto> Cities { get; set; }

        public CityModel(ICityService cityService)
        {
            this.cityService = cityService;
        }
        public async Task OnGet()
        {
            Cities = await cityService.GetAll();
        }
    }
}
