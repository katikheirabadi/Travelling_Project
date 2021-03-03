using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TravellingCore.Dto.Category.GetAllWithId;
using TravellingCore.Dto.Country.GetAllCountries;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Services.Models.Services.CategoryServise;
using TravellingCore.Services.Models.Services.CountryService;
using TravellingCore.Services.SigninServicefoulder;

namespace Travellingfront.Pages
{
    public class SigninModel : PageModel
    {
        private readonly IUserService userService;
        private readonly ICountryService countryService;
        private readonly ICategoryServise categoryServise;

        [BindProperty]
        public SigninInputDTO Signin { get; set; }

        [BindProperty]
        public List<GetallCategoriesWithIdOutPutDto> Allcategories { get; set; }

        [BindProperty]
        public List<GetAllcountries> Allcountries { get; set; }

        [BindProperty]
        public bool State { get; set; }

        public SigninModel(IUserService userService,
                           ICountryService countryService,
                           ICategoryServise categoryServise)
        {
            this.userService = userService;
            this.countryService = countryService;
            this.categoryServise = categoryServise;
        }
        public async Task OnGet()
        {
            var countries = await countryService.GetAll();
            var categories = await categoryServise.GetAll();

            ViewData["Countries"] = new SelectList(countries, "Id", "Name");
            ViewData["categories"] = new SelectList(categories, "Id", "Name");
        }
        public async Task<IActionResult> OnPost()
        {
            try
            {
                if (!ModelState.IsValid)
                    return Page();
                await userService.AddUser(Signin);
                State = true;
                return RedirectToPage("/Login");
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
