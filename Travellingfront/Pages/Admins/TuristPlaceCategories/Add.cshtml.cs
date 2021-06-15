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

namespace Travellingfront.Pages.Admins.TuristPlaceCategories
{
    public class AddModel : PageModel
    {
        private readonly ITuristPlaceCategoryServise turistPlaceCategoryServise;
        private readonly ITuristPlaceService turistPlaceService;
        private readonly ICategoryServise categoryServise;

        public AddModel(ITuristPlaceCategoryServise turistPlaceCategoryServise,
                        ITuristPlaceService turistPlaceService,
                        ICategoryServise categoryServise)
        {
            this.turistPlaceCategoryServise = turistPlaceCategoryServise;
            this.turistPlaceService = turistPlaceService;
            this.categoryServise = categoryServise;
        } 
        [BindProperty]
        public RegisterInputDto registerInput { get; set; }
        public bool State { get; set; }
        public async Task OnGet()
        {
            var places = await turistPlaceService.ShowAll();
            var categories = await categoryServise.GetAll();
            ViewData["places"] = new SelectList(places, "Name", "Name");
            ViewData["categories"] = new SelectList(categories, "Name", "Name");
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                await turistPlaceCategoryServise.Register(registerInput);
                State = true;
                return RedirectToPage("./TuristPlaceCategory");

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
