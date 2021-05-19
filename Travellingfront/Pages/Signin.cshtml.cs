using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using TravellingCore.Dto.Category.GetAllWithId;
using TravellingCore.Dto.Country.GetAllCountries;
using TravellingCore.Dto.Sign_in;
using TravellingCore.Services.Models.Services.CategoryServise;
using TravellingCore.Services.Models.Services.CountryService;
using TravellingCore.Services.SigninServicefoulder;
using TravellingCore.Model;
using TravellingCore.Claims;

namespace Travellingfront.Pages
{
    public class SigninModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly ICountryService countryService;
        private readonly ICategoryServise categoryServise;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<SigninModel> _logger;


        public SigninModel(
          UserManager<User> userManager,
          SignInManager<User> signInManager,
          ICountryService countryService,
          ICategoryServise categoryServise,
          ILogger<SigninModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            this.countryService = countryService;
            this.categoryServise = categoryServise;
            _logger = logger;
        }

        [BindProperty]
        public SigninInputDTO Signin { get; set; }
        public string ReturnUrl { get; set; }

        public  async Task OnGet(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            var countries = await countryService.GetAll();
            var categories = await categoryServise.GetAll();

            ViewData["Countries"] = new SelectList(countries, "Id", "Name");
            ViewData["categories"] = new SelectList(categories, "Id", "Name");

           // return Task.CompletedTask;
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var user = new TravellingCore.Model.User
                {
                    FullName = Signin.FullName,
                    UserName = Signin.Username,
                    Password = Signin.Password,
                    RePassword = Signin.RePassword,
                    PhoneNumber = Signin.PhoneNumber,
                    FavoriteCategory = Signin.FavoriteCategory,
                    FavoriteCountry = Signin.FavoriteCountry,
                };


                var result = await _userManager.CreateAsync(user, Signin.Password);
                await _userManager.AddToRoleAsync(user, AppRole.User.ToString());
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return LocalRedirect(returnUrl);
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
