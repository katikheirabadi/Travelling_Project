using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravellingCore.Dto.Compare;
using TravellingCore.Services.Models.Services.CompareService;
using TravellingCore.Services.Models.Services.TuristPlaceService;

namespace Travellingfront.Pages.Compare
{
    public class CompareModel : PageModel
    {
        private readonly ICompareService compareService;
        private readonly ITuristPlaceService turistPlaceService;

        public CompareModel(ICompareService compareService ,ITuristPlaceService turistPlaceService)
        {
            this.compareService = compareService;
            this.turistPlaceService = turistPlaceService;
        }
        [BindProperty]
        public CompareInputDTO compareInput { get; set; }
        [BindProperty]
        public CompareOutputDto compareOutput { get; set; }
        public bool State { get; set; }
        public async Task OnGet()
        {
            var places = await turistPlaceService.ShowAll();

            ViewData["Places"] = new SelectList(places, "Name", "Name");
        }
        public async  Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                compareOutput = await compareService.Compare(compareInput);
                State = true;
                return Page();
            }
            catch (Exception e)
            {
                State = false;
                ViewData["Errore"] = e.Message;
                return Page();
                
            }
        } 
    }
}
