using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Services.Models.Services.TuristPlaceCategoryServise;

namespace Travellingfront.Pages.Admins.TuristPlaceCategories
{
    public class DeleteModel : PageModel
    {
        private readonly ITuristPlaceCategoryServise turistPlaceCategoryServise;

        public DeleteModel(ITuristPlaceCategoryServise turistPlaceCategoryServise)
        {
            this.turistPlaceCategoryServise = turistPlaceCategoryServise;
        }
        public bool State { get; set; }
        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                await turistPlaceCategoryServise.DeleteById(id);
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
