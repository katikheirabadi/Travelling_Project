using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravellingCore.Dto.TuristPlaceCategory.Regisster;
using TravellingCore.Services.Models.Services.CategoryServise;
using TravellingCore.Services.Models.Services.TuristPlaceCategoryServise;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages.Admins.PlaceCategories
{
    public class AddModel : PageModel
    {
        private readonly ITuristPlaceCategoryServise turistPlaceCategoryServise;
        private readonly ICategoryServise categoryServise;
        private readonly ITuristPlaceService turistPlaceService;

        [BindProperty]
        public RegisterInputDto NewPlaceCategory { get; set; }
        [BindProperty]
        public bool State { get; set; }

        public AddModel(ITuristPlaceCategoryServise turistPlaceCategoryServise
                        ,ICategoryServise categoryServise
                        ,ITuristPlaceService turistPlaceService)
        {
            this.turistPlaceCategoryServise = turistPlaceCategoryServise;
            this.categoryServise = categoryServise;
            this.turistPlaceService = turistPlaceService;
        }
        public async Task OnGet()
        {
            var places = await turistPlaceService.ShowAll();
            var categories = await categoryServise.GetAll();

            ViewData["Places"] = new SelectList(places, "Name", "Name");
            ViewData["Categories"] = new SelectList(categories, "Name", "Name");
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                await turistPlaceCategoryServise.Register(NewPlaceCategory);
                State = true;
                return RedirectToPage("./ShowAll");
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
