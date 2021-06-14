using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.TuristPlaceCategory.GetAll;
using TravellingCore.Services.Models.Services.TuristPlaceCategoryServise;

namespace Travellingfront.Pages.Admins.PlaceCategories
{
    public class ShowAllModel : PageModel
    {
        private readonly ITuristPlaceCategoryServise turistPlaceCategoryServise;
 
        [BindProperty]
        public List<GetturistPlaceOutputDto> PlaceCategories { get; set; }

        public ShowAllModel(ITuristPlaceCategoryServise turistPlaceCategoryServise)
        {
            this.turistPlaceCategoryServise = turistPlaceCategoryServise;
        }
        public async Task OnGet()
        {
            PlaceCategories = await turistPlaceCategoryServise.GetAll();
        }
    }
}
