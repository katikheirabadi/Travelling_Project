using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Rate.DeleteRate;
using TravellingCore.Services.Models.Services.RateService;

namespace Travellingfront.Pages.Admins.Rates
{
    public class DeleteModel : PageModel
    {
        private readonly IRateService rateService;
        [BindProperty]
        public Boolean State { get; set; }
        public DeleterateInputDto deleterate { get; set; }
        public DeleteModel(IRateService rateService)
        {
            this.rateService = rateService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                deleterate = new DeleterateInputDto() { RateId = id };
                var result = await rateService.DeleteRate(deleterate);
                State = true;
                return RedirectToPage("./Rate");

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
