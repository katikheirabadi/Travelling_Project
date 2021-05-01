using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Services.Models.Services.CityService;

namespace Travellingfront.Pages.Admins.Cities
{
    public class DeleteModel : PageModel
    {
        private readonly ICityService cityService;

        [BindProperty]
        public bool State { get; set; }

        public DeleteModel(ICityService cityService)
        {
            this.cityService = cityService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                await cityService.DeleteById(id);
                State = true;
                return RedirectToPage("./City");
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
