using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.TuristPlaceCategory.Regisster;
using TravellingCore.Services.Models.Services.TuristPlaceCategoryServise;

namespace Travellingfront.Pages.Admins.TuristPlaceCategories
{
    public class AddModel : PageModel
    {
        private readonly ITuristPlaceCategoryServise turistPlaceCategoryServise;

        public AddModel(ITuristPlaceCategoryServise turistPlaceCategoryServise)
        {
            this.turistPlaceCategoryServise = turistPlaceCategoryServise;
        }
        [BindProperty]
        public RegisterInputDto registerInput { get; set; }
        public bool State { get; set; }
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
