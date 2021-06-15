using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Services.Models.Services.TuristPlaceCategoryServise;

namespace Travellingfront.Pages.Admins.PlaceCategories
{
    public class DeleteModel : PageModel
    {
        private readonly ITuristPlaceCategoryServise turistPlaceCategoryServise;

        [BindProperty]
        public bool State { get; set; }
        public DeleteModel(ITuristPlaceCategoryServise turistPlaceCategoryServise)
        {
            this.turistPlaceCategoryServise = turistPlaceCategoryServise;
        }
        public async Task<IActionResult> OnGet(int Id)
        {
            try
            {
                await turistPlaceCategoryServise.DeleteById(Id);
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
