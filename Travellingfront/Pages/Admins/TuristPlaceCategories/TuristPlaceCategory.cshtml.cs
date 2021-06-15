using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.TuristPlaceCategory;
using TravellingCore.Services.Models.Services.TuristPlaceCategoryServise;

namespace Travellingfront.Pages.Admins.TuristPlaceCategories
{
    public class TuristPlaceCategoryModel : PageModel
    {
        private readonly ITuristPlaceCategoryServise turistPlaceCategoryServise;

        public TuristPlaceCategoryModel(ITuristPlaceCategoryServise turistPlaceCategoryServise)
        {
            this.turistPlaceCategoryServise = turistPlaceCategoryServise;
        }
        public List<ShowAllTuristPlaceCategoryOutputDtol> showAllTuristPlace { get; set; } 
        public async Task OnGet()
        {
            showAllTuristPlace = await turistPlaceCategoryServise.ShowAll();
        }
    }
}
