using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TravellingCore.Dto.Country.Get_CountrywithId;
using TravellingCore.Services.Models.Services.CountryService;

namespace Travellingfront.Pages.Admins.Countries
{
    public class DeleteModel : PageModel
    {
        private readonly ICountryService countryService;
        [BindProperty]
        public bool State { get; set; }
        [BindProperty]
        public GetCountryWithIdOutputDto country { get; set; }

        public DeleteModel(ICountryService countryService)
        {
            this.countryService = countryService;
        }
        public async Task<IActionResult> OnGet(int id)
        {
            try
            {
                country = await countryService.GetCountryWithId(id);
                await countryService.DeletById(id);
                State = true;
                return RedirectToPage("./Country");
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
